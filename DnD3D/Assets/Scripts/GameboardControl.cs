using System.Collections;
using UnityEngine;

public class GameboardControl : MonoBehaviour {
    //Grid
    public Character[] characters;
    public Tile[, ] tiles;
    public static ArrayList doors;
    //Creation of Tiles and Characters
    [SerializeField] int maxColumns = 10;
    [SerializeField] int maxRows = 10;
    [SerializeField] float size;
    [SerializeField] private int idt;
    [SerializeField] private int idc;
    [SerializeField] private int cMax;
    UIController uiC;
    CameraController cam;
    //Misc
    [SerializeField] private int round;
    [SerializeField] private Tile currentTile;
    [SerializeField] private Tile previousTile = null;
    [SerializeField] private TileEvent tileEvent;
    [SerializeField] Character player;
    CharacterMovement characterMouvement;
    // Start is called before the first frame update
    public void Awake () {
        cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
        uiC = GameObject.Find ("Canvas").GetComponent<UIController> ();
    }
    public void StartingGame (int c) {
        round = 1;
        idt = 0; //tile id
        tiles = new Tile[maxColumns, maxRows];
        doors = new ArrayList ();
        size = 4f;
        idc = 1; //character id
        cMax = c; // max characters
        characters = new Character[cMax]; // set character list
        Spawner s = GetComponent<Spawner> ();

        //Creating tiles
        for (int x = 0; x < maxColumns; x++) {
            for (int z = 0; z < maxRows; z++) {
                tiles[x, z] = s.AddTile (idt, x, z, size, maxRows);
                tiles[x, z].GetComponent<TileEvent> ().SetTileEvent (Random.Range (0, 9));
                idt++;
            }
        }
        MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (tiles);
        ma.CreateMaze ();
        foreach (Tile t in tiles) {
            t.SetVisited (false);
        }
    }
    // Update is called once per frame
    void Update () {
        if (characters[idc - 1] == null) {
            CreateCharacter ();
        } else {
            player = characters[idc - 1];
            characterMouvement = player.GetComponent<CharacterMovement> ();
            ActivateDoors (false);
            currentTile = WhatTile (player);
            currentTile.SetVisited (true);
            if (previousTile != currentTile) {
                if (previousTile != null)
                    player.SetMouvementUI (-1);

                previousTile = currentTile;
            }
            if (player.GetMouvementUI () == 0)
                ActivateDoors (true);
            if (player.GetisTurn () && !characterMouvement.IsAttacking ()) {
                if (Input.GetKeyUp (KeyCode.F)) {
                    NextTurn ();
                    if (idc == 1) {
                        round++;
                    }
                }
                if (Input.GetKeyUp (KeyCode.Z))
                    Check ();
            }
        }
    }
    public void SetIdc (int i) {
        idc = i;
    }
    public void SetPreviousTile () {
        previousTile = null;
    }
    public void CreateCharacter () {
        int c = Random.Range (0, maxColumns);
        int r = Random.Range (0, maxRows);
        Vector3 coor = new Vector3 (tiles[c, r].transform.localPosition.x, 3f, tiles[c, r].transform.localPosition.z);
        uiC.SetCreationUI (coor);
    }
    public void AddInCharacters (int i) {
        characters[i - 1] = GameObject.FindGameObjectWithTag ("Player" + i).GetComponent<Character> ();
        characters[i - 1].SetClass ();
        SetStartingPower ();
    }
    public Character[] GetCharacters () => characters;
    public Character GetPlayer () => player;
    public void AddInDoors (GameObject d) {
        doors.Add (d);
    }
    public int GetIdc () => idc;
    public void ActivateDoors (bool t) {
        foreach (GameObject d in doors) {
            d.transform.GetChild (0).gameObject.SetActive (t);
        }
    }
    public Tile WhatTile (Character c) {
        Vector3 minTile;
        Vector3 maxTile;
        foreach (Tile t in tiles) {
            minTile = t.transform.localPosition + new Vector3 (-size / 2, 0, -size / 2);;
            maxTile = t.transform.localPosition + new Vector3 (size / 2, 0, size / 2);;
            if (c.transform.localPosition.x >= minTile.x && c.transform.localPosition.z >= minTile.z && c.transform.localPosition.x <= maxTile.x && c.transform.localPosition.z <= maxTile.z)
                return t;
        }
        return null;
    }
    public Tile GetTile (int c, int r) {
        if (c < 0 || r < 0 || c >= maxColumns || r >= maxRows)
            return null;
        else
            return tiles[c, r];
    }
    public int GetRound () => round;
    public void NextTurn () {
        player.SetisTurn (false);
        if (player.GetId () < cMax) {
            idc++;

        } else {
            idc = 1;
            round++;
        }
        player = characters[idc - 1];
        player.SetActionUI (player.GetAction () - player.GetActionUI ());
        player.SetRangeUI (player.GetRange () - player.GetRangeUI ());
        player.SetMouvementUI (player.GetMouvement () - player.GetMouvementUI ());
        player.SetisTurn (true);
        
        for (int p = 0; p < 3; p++) {
            if (player.GetPower (p) != null && player.GetPower (p).GetCooldownUI () > 0)
                player.GetPower (p).SetCooldownUI (-1);
        }
        //SetUI
        uiC.NextTurnUI (player);

        SetPreviousTile ();
        cam.SetCamera (idc);
    }
    public void Check () {
        if (player.GetActionUI () > 0) {
            tileEvent = currentTile.GetComponent<TileEvent> ();
            player.SetActionUI (-1);
            uiC.CheckUI (tileEvent);
        }
    }
    public void SetStartingPower () {
        if (characters[idc - 1].GetClass () == "Warrior")
            characters[idc - 1].AddPower (0);
        else if (characters[idc - 1].GetClass () == "Rogue")
            characters[idc - 1].AddPower (1);
        else if (characters[idc - 1].GetClass () == "Mage")
            characters[idc - 1].AddPower (2);
        else if (characters[idc - 1].GetClass () == "Cleric")
            characters[idc - 1].AddPower (3);
    }
    public void AddNewPower (Power i) {
        player.AddPower (i);
    }
    public void AddNewItem (Item i) {
        player.AddItem (i);
    }
}