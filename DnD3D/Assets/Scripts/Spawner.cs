using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject tilePrefab;
    public GameObject wallPrefab;
    public GameObject characterPrefab;

    public Tile AddTile (int id, int c, int r, float size, int mazeRows) {
        //Tile Spawning
        GameboardControl gb = GetComponent<GameboardControl> ();
        GameObject tileObject = Instantiate (tilePrefab, new Vector3 (c * size, 0, r * size), Quaternion.identity);
        tileObject.transform.SetParent (gameObject.transform, false);
        string name = "Tile" + c + "," + r;
        tileObject.name = name;
        Tile tile = tileObject.GetComponent<Tile> ();
        //Walls Spawning
        if (c == 0) {
            GameObject westWall = Instantiate (wallPrefab, new Vector3 (-size / 8, 2, 0), Quaternion.identity) as GameObject;
            westWall.name = "West Wall " + c + "," + r;
            westWall.transform.SetParent (tileObject.transform, false);
            tile.SetWestWall (westWall);
        }
        GameObject eastWall = Instantiate (wallPrefab, new Vector3 (size / 8, 2, 0), Quaternion.identity) as GameObject;
        eastWall.name = "East Wall " + c + "," + r;
        eastWall.transform.SetParent (tileObject.transform, false);
        tile.SetEastWall (eastWall);
        if (r == mazeRows - 1) {
            GameObject northWall = Instantiate (wallPrefab, new Vector3 (0, 2, size / 8), Quaternion.identity) as GameObject;
            northWall.name = "North Wall " + c + "," + r;
            northWall.transform.Rotate (new Vector3 (0, 90, 0));
            northWall.transform.SetParent (tileObject.transform, false);
            tile.SetNorthWall (northWall);
        }
        GameObject southWall = Instantiate (wallPrefab, new Vector3 (0, 2, -size / 8), Quaternion.identity) as GameObject;
        southWall.name = "South Wall " + c + "," + r;
        southWall.transform.Rotate (new Vector3 (0, 90, 0));
        southWall.transform.SetParent (tileObject.transform, false);
        tile.SetSouthWall (southWall);

        tile.SetTile (new Vector3 (c, 0, r));
        return tile;
    }

    public void SetNewCharacter (int idc, string name, string c, Vector3 charCoor) {
        Character chara = characterPrefab.GetComponent<Character> ();
        GameboardControl gb = gameObject.GetComponent<GameboardControl> ();
        if (c == "Warrior") {
            chara.SetWarrior (idc, charCoor, name);
        } else if (c == "Rogue")
            chara.SetRogue (idc, charCoor, name);
        else if (c == "Mage")
            chara.SetMage (idc, charCoor, name);
        else
            chara.SetCleric (idc, charCoor, name);

        gb.AddInCharacters (idc);
        UIController uiC = GameObject.Find ("Canvas").GetComponent<UIController> ();
        uiC.SetCreationUI ();
    }
}