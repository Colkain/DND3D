using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    private bool isAttacking;
    GameboardControl gameboard;
    //Mouvement
    public float Speed = 4f;
    public float gravity = -9.81f;
    public Vector3 Drag;
    private CharacterController _controller;
    private Vector3 _velocity;
    //Attack
    public static List<Tile> cells;
    public Color startColor;
    public Color endColor;
    RaycastHit hit;
    Character c;
    int range;
    Tile attackedTile;
    Ray ray;
    // Start is called before the first frame update
    void Start () {
        _controller = GetComponent<CharacterController> ();
        gameboard = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
        isAttacking = false;
        c = gameObject.GetComponent<Character> ();
        range = c.GetRange ();
    }
    // Update is called once per frame
    void Update () {
        if (c.GetIsTurn ()) {
            if (!isAttacking) {
                Move ();
                if (Input.GetKeyUp (KeyCode.Return))
                    gameboard.EndTurn ();
            }
            Attack ();
        }
    }
    private bool IsTurn () {
        return true;
    }
    public void Attack () {
        if (Input.GetKey (KeyCode.Space)) {
            isAttacking = true;
            cells = new List<Tile> ();
            cells.Add (gameboard.WhatTile (c));
            Vector3 coor = gameboard.WhatTile (c).GetCoor ();
            if (range != 0) {
                for (int i = 0; i <= range; i++) {
                    cells.Add (gameboard.GetTile ((int) coor.x + i, (int) coor.z));
                    cells.Add (gameboard.GetTile ((int) coor.x - i, (int) coor.z));
                }
                for (int j = 0; j <= range; j++) {
                    cells.Add (gameboard.GetTile ((int) coor.x, (int) coor.z + j));
                    cells.Add (gameboard.GetTile ((int) coor.x, (int) coor.z - j));
                }
            }
            foreach (Tile t in cells) {
                if (t != null)
                    t.GetComponent<Renderer> ().material.color = endColor;
            }
            StartCoroutine (Attacking (c));
        }
        if (isAttacking) {
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
                isAttacking = false;
                foreach (Tile t in cells) {
                    if (t != null)
                        t.GetComponent<Renderer> ().material.color = startColor;
                } //attack function
                foreach (Character chara in gameboard.GetCharacters ()) {
                    if (c != chara) {
                        if (IsCharacterHit (chara, attackedTile)) {
                            chara.SetHealth (chara.GetHealth () - c.GetAtttack ());
                        }
                    }
                }
            }
        }
    }
    public void Move () {
        _velocity.y += gravity * Time.deltaTime;
        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;
        _controller.Move (_velocity * Time.deltaTime);
        if (_controller.isGrounded)
            _velocity.y = 0;

        Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        _controller.Move (move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
            transform.forward = move;
    }

    IEnumerator Attacking (Character c) {
        while (!Input.GetMouseButtonUp (0))
            yield return null;
    }
    public bool IsCharacterHit (Character c, Tile t) {
        if (gameboard.WhatTile (c) == t)
            return true;
        else
            return false;
    }
}