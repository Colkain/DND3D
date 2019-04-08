using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    private CharacterMovement cm;
    public static List<Tile> cells;

    public Color startColor;
    public Color endColor;
    GameboardControl gb;
    RaycastHit hit;
    Character c;
    int range;
    Tile attackedTile;
    Ray ray;
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
                StartCoroutine (Attack (c));
            }
            if (!cm.GetAction ()) {
                ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                if (Physics.Raycast (ray, out hit, 100)) {
                    foreach (Tile t in cells) {
                        if (t != null) {
                            if (t.name == hit.transform.gameObject.name) {
                                t.GetComponent<Renderer> ().material.color = Color.green;
                                attackedTile = t;
                            } else {
                                t.GetComponent<Renderer> ().material.color = endColor;
                            }
                        }
                    }
                }
                if (Input.GetMouseButtonUp (0)) {
                    cm.SetAction (true);
                    foreach (Tile t in cells) {
                        if (t != null)
                            t.GetComponent<Renderer> ().material.color = startColor;
                    } //attack function
                    foreach (Character chara in gb.GetCharacters ()) {
                        if (c != chara) {
                            if (IsCharacterHit (chara, attackedTile)) {
                                chara.SetHealth (chara.GetHealth () - c.GetAtttack());
                            }
                        }
                    }
                }
            }
        }
    }
    IEnumerator Attack (Character c) {
        while (!Input.GetMouseButtonUp (0))
            yield return null;
    }
    public bool IsCharacterHit (Character c, Tile t) {
        if (gb.WhatTile (c) == t)
            return true;
        else
            return false;
    }
}