using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private bool visited = false;
    public GameObject doorPrefab;
    private GameObject northWall, westWall, eastWall, southWall;
    [SerializeField] private Vector3 coor;
    public GameObject[] walls;
    [SerializeField] private List<GameObject> doors;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    void Awake () {
        doors = new List<GameObject> ();
    }
    void Update () {
        if (visited) {
            light1.GetComponent<Light> ().enabled = true;
            light2.GetComponent<Light> ().enabled = true;
            light3.GetComponent<Light> ().enabled = true;
            light4.GetComponent<Light> ().enabled = true;
        } else {
            light1.GetComponent<Light> ().enabled = false;
            light2.GetComponent<Light> ().enabled = false;
            light3.GetComponent<Light> ().enabled = false;
            light4.GetComponent<Light> ().enabled = false;
        }
    }
    public void AddDoor (GameObject w) {
        GameObject doorObject = Instantiate (doorPrefab, w.transform.localPosition, Quaternion.identity);
        doorObject.transform.Rotate (w.transform.rotation.eulerAngles);
        doorObject.transform.SetParent (gameObject.transform, false);
        GameboardControl gb = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
        doors.Add (doorObject);
    }
    public void SetDoors (bool t) {
        if (!t) {
            //open
            foreach (GameObject d in doors) {
                while (d.transform.GetChild (0).gameObject.transform.localPosition.y >= -1)
                    d.transform.GetChild (0).gameObject.transform.Translate (Vector3.down * Time.deltaTime);
            }
        } else {
            //close
            foreach (GameObject d in doors) {
                while (d.transform.GetChild (0).gameObject.transform.localPosition.y <= 0)
                    d.transform.GetChild (0).gameObject.transform.Translate (Vector3.up * Time.deltaTime);
            }
        }
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