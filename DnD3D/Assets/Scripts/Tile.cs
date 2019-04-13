using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private bool visited = false;
    public GameObject doorPrefab;
    private GameObject northWall, westWall, eastWall, southWall;
    [SerializeField] private Vector3 coor;
    public GameObject[] walls;
    Material[] mat;
    public Color wallColor;
    public Color tileColor;
    public void AddDoor (GameObject w) {
        GameObject doorObject = Instantiate (doorPrefab, w.transform.localPosition, Quaternion.identity);
        doorObject.transform.Rotate (w.transform.rotation.eulerAngles);
        doorObject.transform.SetParent (gameObject.transform, false);
        GameboardControl gb = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
        gb.AddInDoors (doorObject);
    }

    public void Update () {
        // Renderer renderer = GetComponent<Renderer> ();
        // Material mat = renderer.material;
        if (visited) { } else {
            foreach (Material m in mat) {
                // m.SetColor = m.GetColor () * Mathf.LinearToGammaSpace (emission);
            } 
        }
    }
    public void SetMaterials () {
        for (int i = 0; i < 3; i++) {
            if (walls[i] != null) {
                mat[i] = walls[i].GetComponent<Renderer> ().material;
            }
        }
        mat[4] = GetComponent<Renderer> ().material;
    }
    public bool GetVisited () {
        return visited;
    }
    public void SetVisited (bool v) {
        visited = v;
    }
    public void SetTile (Vector3 c) {
        coor = c;
        walls = new GameObject[4];
        walls[0] = northWall;
        walls[1] = westWall;
        walls[2] = eastWall;
        walls[3] = southWall;
    }
    public void SetWestWall (GameObject w) {
        westWall = w;
    }
    public void SetEastWall (GameObject w) {
        eastWall = w;
    }
    public void SetNorthWall (GameObject w) {
        northWall = w;
    }
    public void SetSouthWall (GameObject w) {
        southWall = w;
    }
    public GameObject GetWestWall () {
        return westWall;
    }
    public GameObject GetEastWall () {
        return eastWall;
    }
    public GameObject GetSouthWall () {
        return southWall;
    }
    public GameObject GetNorthWall () {
        return northWall;
    }
    public void SetActive (bool a) {
        SetActive (a);
    }
    public Vector3 GetCoor () {
        return coor;
    }
}