using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    CharacterMovement cm;
    [SerializeField] private Character player;
    CameraController cam;
    Dropdown m_Dropdown;
    public GameObject gameBoardPrefab;
    [SerializeField] private static int cMax;
    [SerializeField] private Vector3 characterCoor;
    InputField nameField;
    private GameObject creationUI;
    private GameObject statUI;
    private GameObject controlsUI;
    private GameObject itemsUI;
    private GameObject popupUI;
    GameboardControl gameBoard;
    //inGame Texts
    GameObject nameC;
    GameObject classC;
    GameObject level;
    GameObject action;
    GameObject health;
    GameObject mouvement;
    GameObject strength;
    GameObject agility;
    GameObject intelligence;
    GameObject wisdom;
    GameObject range;
    //inGame ControlsUI Buttons
    Button attackB;
    Button checkB;
    Button endTurn;
    //Powers UI
    Button[] powersB;
    Power power;
    //Items UI
    Button[] itemsB;
    Button[] itemsBC;
    Item item;
    int selectedItem;
    bool itemInt;
    //Popup UI
    Button popupB;
    TileEvent tileEvent;
    bool startOfTheGame;
    public void Start () {
        powersB = new Button[3];
        itemsB = new Button[6];
        itemsBC = new Button[2];
        creationUI = GameObject.Find ("CreationUI");
        statUI = GameObject.Find ("InGameUI").transform.GetChild (0).gameObject;
        controlsUI = GameObject.Find ("InGameUI").transform.GetChild (1).gameObject;
        itemsUI = GameObject.Find ("InGameUI").transform.GetChild (2).gameObject;
        popupUI = GameObject.Find ("InGameUI").transform.GetChild (3).gameObject;

        attackB = controlsUI.transform.GetChild (2).GetComponent<Button> ();
        checkB = controlsUI.transform.GetChild (3).GetComponent<Button> ();

        powersB[0] = controlsUI.transform.GetChild (4).GetComponent<Button> ();
        powersB[1] = controlsUI.transform.GetChild (5).GetComponent<Button> ();
        powersB[2] = controlsUI.transform.GetChild (6).GetComponent<Button> ();

        itemsB[0] = itemsUI.transform.GetChild (2).GetComponent<Button> ();
        itemsB[1] = itemsUI.transform.GetChild (3).GetComponent<Button> ();
        itemsB[2] = itemsUI.transform.GetChild (4).GetComponent<Button> ();
        itemsB[3] = itemsUI.transform.GetChild (5).GetComponent<Button> ();
        itemsB[4] = itemsUI.transform.GetChild (6).GetComponent<Button> ();
        itemsB[5] = itemsUI.transform.GetChild (7).GetComponent<Button> ();
        itemsBC[0] = itemsUI.transform.GetChild (8).GetComponent<Button> ();
        itemsBC[1] = itemsUI.transform.GetChild (9).GetComponent<Button> ();
        itemInt = false;

        popupB = controlsUI.transform.GetChild (3).GetComponent<Button> ();
        endTurn = controlsUI.transform.GetChild (7).GetComponent<Button> ();

        SetCreationUI ();
        statUI.SetActive (false);
        controlsUI.SetActive (false);
        itemsUI.SetActive (false);
        popupUI.SetActive (false);
        cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
        startOfTheGame = true;
    }
    public void SettingUp () {
        m_Dropdown = GameObject.FindGameObjectWithTag ("DropDown").GetComponent<Dropdown> ();
        cMax = m_Dropdown.value + 2;
        GameObject gameBoardObject = Instantiate (gameBoardPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        gameBoard = gameBoardObject.GetComponent<GameboardControl> ();
        GameObject.Find ("SettingupUI").SetActive (false);
        gameBoard.StartingGame (cMax);
    }
    public void CreateCharacter (string c) {
        nameField = GameObject.FindGameObjectWithTag ("NameField").GetComponent<InputField> ();
        Spawner s = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<Spawner> ();
        s.SetNewCharacter (gameBoard.GetIdc (), nameField.text, c, characterCoor);
        SetCreationUI ();
        if (gameBoard.GetIdc () == cMax) {
            statUI.SetActive (true);
            controlsUI.SetActive (true);
            itemsUI.SetActive (true);
            gameBoard.SetIdc (1);
            string name = "Player" + gameBoard.GetIdc ();
            Character player = GameObject.FindWithTag (name).GetComponent<Character> ();
            player.SetisTurn (true);
            gameBoard.SetPreviousTile ();
            cam.SetCamera (gameBoard.GetIdc ());
        } else {
            gameBoard.SetIdc (gameBoard.GetIdc () + 1);
            nameField.text = null;
        }
    }
    public void SetCreationUI () {
        creationUI.SetActive (false);
    }
    public void SetCreationUI (Vector3 coor) {
        characterCoor = coor;
        creationUI.SetActive (true);
        Text text = GameObject.Find ("PlayerNumber").GetComponent<Text> ();
        text.text = "Player number:" + gameBoard.GetIdc ();
    }
    public void SetCharUI (Character c) {
        player = c;
        cm = player.GetComponent<CharacterMovement> ();
        nameC = GameObject.Find ("Name");
        classC = GameObject.Find ("Class");
        level = GameObject.Find ("Level");
        action = GameObject.Find ("Action");
        health = GameObject.Find ("Health");
        mouvement = GameObject.Find ("Mouvement");
        strength = GameObject.Find ("Strength");
        agility = GameObject.Find ("Agility");
        intelligence = GameObject.Find ("Intelligence");
        wisdom = GameObject.Find ("Wisdom");
        range = GameObject.Find ("Range");

        if (startOfTheGame) {
            SetLevelUpButtons (false);
            startOfTheGame = false;
        }
        if (player.GetActionUI () == 0) {
            attackB.transform.GetChild (0).gameObject.SetActive (true);
            checkB.transform.GetChild (0).gameObject.SetActive (true);
        } else {
            attackB.transform.GetChild (0).gameObject.SetActive (false);
            checkB.transform.GetChild (0).gameObject.SetActive (false);
        }
        SetPowersButtons ();
        SetItemsButtons ();
        if (!itemInt) {
            itemsBC[0].transform.gameObject.SetActive (false);
            itemsBC[1].transform.gameObject.SetActive (false);
        }
        nameC.GetComponent<Text> ().text = c.GetName ();
        classC.GetComponent<Text> ().text = c.GetClass ();
        level.GetComponent<Text> ().text = "Lvl:" + c.GetLevel ().ToString ();
        action.GetComponent<Text> ().text = "Action:" + c.GetActionUI ();
        health.GetComponent<Text> ().text = "HP:" + c.GetHealth ().ToString () + "/" + c.GetMaxHealth ().ToString ();
        mouvement.GetComponent<Text> ().text = "Mv:" + c.GetMouvementUI ().ToString ();
        strength.GetComponent<Text> ().text = "Str:" + c.GetStrength ().ToString ();
        agility.GetComponent<Text> ().text = "Agi:" + c.GetAgility ().ToString ();
        intelligence.GetComponent<Text> ().text = "Int:" + c.GetIntelligence ().ToString ();
        wisdom.GetComponent<Text> ().text = "Wis:" + c.GetWisdom ().ToString ();
        range.GetComponent<Text> ().text = "Ran:" + c.GetRangeUI ().ToString ();
    }

    public void SetLevelUpButtons (bool a) {
        mouvement.transform.GetChild (0).gameObject.SetActive (a);
        health.transform.GetChild (0).gameObject.SetActive (a);
        strength.transform.GetChild (0).gameObject.SetActive (a);
        agility.transform.GetChild (0).gameObject.SetActive (a);
        intelligence.transform.GetChild (0).gameObject.SetActive (a);
        wisdom.transform.GetChild (0).gameObject.SetActive (a);
    }
    public void LevelUp (int stat) {
        gameBoard.GetCharacters () [gameBoard.GetIdc () - 1].LevelUp (stat);
        SetLevelUpButtons (false);
    }

    public void SetPowersButtons () {
        for (int i = 0; i < 3; i++) {
            power = player.GetPower (i);
            if (power == null) {
                powersB[i].transform.GetChild (0).gameObject.SetActive (true);
                powersB[i].transform.GetChild (2).gameObject.SetActive (false);
            } else {
                powersB[i].transform.GetChild (1).gameObject.GetComponent<Text> ().text = power.GetName ();
                if (power.GetCooldownUI () > 0) {
                    powersB[i].transform.GetChild (0).gameObject.SetActive (true);
                    powersB[i].transform.GetChild (2).gameObject.SetActive (true);
                    powersB[i].transform.GetChild (2).gameObject.GetComponent<Text> ().text = (power.GetCooldownUI ().ToString ());
                } else {
                    powersB[i].transform.GetChild (0).gameObject.SetActive (false);
                    powersB[i].transform.GetChild (2).gameObject.SetActive (false);
                }
            }
        }
    }
    public void SetItemsButtons () {
        if (!itemInt) {
            for (int i = 0; i < 6; i++) {
                item = player.GetItem (i);
                if (item == null) {
                    itemsB[i].transform.gameObject.SetActive (false);
                } else {
                    itemsB[i].transform.gameObject.SetActive (true);
                    itemsB[i].transform.GetChild (1).gameObject.GetComponent<Text> ().text = (item.GetName ());
                    if (item.GetTypeI () == "Equipment") {
                        if (!item.CheckReq (player)) {
                            itemsB[i].transform.GetChild (0).gameObject.SetActive (true);
                        } else {
                            itemsB[i].transform.GetChild (0).gameObject.SetActive (false);
                        }
                    } else
                        itemsB[i].transform.GetChild (0).gameObject.SetActive (false);
                }
            }
        }
    }
    public void ItemInteraction (int i) {
        if (!itemInt) {
            itemInt = true;
            for (int a = 0; a < itemsB.Length; a++) {
                if (a != i)
                    itemsB[a].transform.gameObject.SetActive (false);
            }
            itemsBC[0].transform.gameObject.SetActive (true);
            itemsBC[1].transform.gameObject.SetActive (true);
            selectedItem = i;
        }
    }
    public void ItemAction (int a) {
        if (a == 6) {
            item = player.GetItem (selectedItem);
            if (item.GetTypeI () == "Equipment" && !item.CheckReq (player)) {
                Debug.Log ("error item action");
            } else {
                if (!item.GetEquipped ()) {
                    player.SetMouvement (item.GetEffect (0));
                    player.SetMouvementUI (item.GetEffect (0));
                    player.SetMaxHealth (item.GetEffect (1));
                    player.SetHealth (item.GetEffect (2));
                    player.SetStrength (item.GetEffect (3));
                    player.SetAgility (item.GetEffect (4));
                    player.SetIntelligence (item.GetEffect (5));
                    player.SetWisdom (item.GetEffect (6));
                    player.SetBonusDamage (item.GetEffect (7));
                    player.SetRange (item.GetEffect (8));
                    player.SetRangeUI (item.GetEffect (8));
                    if (item.GetTypeI () == "Equipment") {
                        itemsB[selectedItem].GetComponent<Image> ().color = Color.green;
                        item.SetEquiped (true);
                    } else {
                        player.RemoveItem (selectedItem);
                    }
                }
            }
        } else if (a == 7) {
            if (item.GetTypeI () == "Equipment" && item.GetEquipped ()) {
                player.SetMouvement (-item.GetEffect (0));
                player.SetMouvementUI (-item.GetEffect (0));
                player.SetMaxHealth (-item.GetEffect (1));
                player.SetHealth (-item.GetEffect (2));
                player.SetStrength (-item.GetEffect (3));
                player.SetAgility (item.GetEffect (4));
                player.SetIntelligence (-item.GetEffect (5));
                player.SetWisdom (-item.GetEffect (6));
                player.SetBonusDamage (-item.GetEffect (7));
                player.SetRange (-item.GetEffect (8));
                player.SetRangeUI (-item.GetEffect (8));
            }
            player.RemoveItem (selectedItem);
        }
        itemInt = false;
        for (int b = 0; b < itemsB.Length; b++) {
            itemsB[b].transform.gameObject.SetActive (true);
        }
        itemsBC[0].transform.gameObject.SetActive (false);
        itemsBC[1].transform.gameObject.SetActive (false);
    }
    public void EndTurn () {
        gameBoard.NextTurn ();
    }
    public void Attack () {
        cm.SetButtonClicked (true);
        cm.Attack ();
    }
    public void UsePower (int i) {
        cm.UsePower (i);
    }
    public void Check () {
        gameBoard.Check ();
    }
    public void AcceptPopup () {
        if (tileEvent.GetId () == 0)
            gameBoard.AddNewPower (tileEvent.GetPower ());
        else if (tileEvent.GetId () == 1)
            gameBoard.AddNewItem (tileEvent.GetItem ());
        else {
            tileEvent.GetHap ().ActivateHap (player);
            popupUI.transform.GetChild (2).GetComponent<Text> ().text = tileEvent.GetHap ().GetDescription ();
        }
        tileEvent.ClearEvent ();
        // popupUI.transform.GetChild (3).gameObject.SetActive (false);
        popupUI.SetActive (false);
    }
    public void ClosePopupUI () {
        popupUI.SetActive (false);
    }
    public void CheckUI (TileEvent te) {
        tileEvent = te;
        popupUI.SetActive (true);
        popupUI.transform.GetChild (1).GetComponent<Text> ().text = te.GetNameE ();
        popupUI.transform.GetChild (2).GetComponent<Text> ().text = te.GetDescription ();
        if (tileEvent.GetId () > 2)
            popupUI.transform.GetChild (3).gameObject.SetActive (false);
        else
            popupUI.transform.GetChild (3).gameObject.SetActive (true);
    }
    public void SetRoundUI (int r) {
        controlsUI.transform.GetChild (8).GetComponent<Text> ().text = "Round:" + r;
    }
}