using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    private CharacterMovement cm;
    public static List<Tile> cells;

    public Color startColor;
    public Color endColor;
    GameboardControl gb;
    Character c;
    int range;

    void Start () {
        cm = gameObject.GetComponent<CharacterMovement> ();
        c = gameObject.GetComponent<Character> ();
        range = c.GetRange ();
        gb = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
    }
    void Update () {
        if (cm.IsTurn ()) {
            if (Input.GetKey (KeyCode.Space)) {
                cm.SetAction (false);
                cells = new List<Tile> ();
                cells.Add (gb.WhatTile (c));
                Vector3 coor = gb.WhatTile (c).GetCoor ();
                if (range != 0) {
                    for (int i = 0; i <= range; i++) {
                        cells.Add (gb.GetTile ((int) coor.x + i, (int) coor.z));
                        cells.Add (gb.GetTile ((int) coor.x - i, (int) coor.z));
                    }
                    for (int j = 0; j <= range; j++) {
                        cells.Add (gb.GetTile ((int) coor.x, (int) coor.z + j));
                        cells.Add (gb.GetTile ((int) coor.x, (int) coor.z - j));
                    }
                }
                foreach (Tile t in cells) {
                    if (t != null)
                        t.GetComponent<Renderer> ().material.color = endColor;
                }
                StartCoroutine (Hover ());

            }
        }
    }
    IEnumerator Hover () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        while (!Input.GetMouseButtonUp (0)) {//Failed Hover
            if (Physics.Raycast (ray, out hit, 100)) {
                foreach (Tile t in cells) {
                    if (t != null) {
                        if (t.name == hit.transform.gameObject.name) {
                            t.GetComponent<Renderer> ().material.color = Color.green;
                        } else {
                            t.GetComponent<Renderer> ().material.color = endColor;
                        }
                    }
                }
            }
            yield return null;
        }
        foreach (Tile t in cells) {
            if (t != null) {
                t.GetComponent<Renderer> ().material.color = startColor;
                //attack
            }
        }
        cm.SetAction (true);
    }
}