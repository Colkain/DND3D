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
    Character player;
    int range;
    Tile attackedTile;
    Ray ray;
    bool buttonClicked;
    // Start is called before the first frame update
    void Start () {
        _controller = GetComponent<CharacterController> ();
        gameboard = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
        isAttacking = false;
        player = gameObject.GetComponent<Character> ();
        buttonClicked = false;
    }
    // Update is called once per frame
    void Update () {
        if (player.GetisTurn ()) {
            gameObject.GetComponent<Collider> ().enabled = true;
            Move ();
            Attack ();
            PreUsePower ();
        } else {
            gameObject.GetComponent<Collider> ().enabled = false;
        }
    }
    public void PreUsePower () {
        if (Input.GetButtonUp ("Power1"))
            UsePower (0);
        else if (Input.GetButtonUp ("Power2"))
            UsePower (1);
        else if (Input.GetButtonUp ("Power3"))
            UsePower (2);
    }
    public void UsePower (int i) {
        player.ActivateEffect (player.GetPower (i));
    }
    public void Attack () {
        if (player.GetActionUI () > 0) {
            if (Input.GetButtonUp ("Attack") || buttonClicked == true) {
                isAttacking = true;
                cells = new List<Tile> ();
                cells.Add (gameboard.WhatTile (player));
                Vector3 coor = gameboard.WhatTile (player).GetCoor ();
                range = player.GetRange ();
                if (range >= 0) {
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
                StartCoroutine (Attacking (player));
            }
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
            if (Input.GetMouseButtonDown (0)) {
                isAttacking = false;
                buttonClicked = false;
                foreach (Tile t in cells) {
                    if (t != null)
                        t.GetComponent<Renderer> ().material.color = startColor;
                } //attack function
                foreach (Character chara in gameboard.GetCharacters ()) {
                    if (player != chara) {
                        if (IsCharacterHit (chara, attackedTile)) {
                            if (range == 0)
                                player.GetAnimator ().SetTrigger ("Attack");
                            else
                                player.GetAnimator ().SetTrigger ("RangedAttack");
                            chara.SetHealth (-player.GetAttack ());
                            player.SetActionUI (-1);
                        }
                    }
                }
            }
        }

    }
    public void Move () {
        if (!isAttacking) {
            _velocity.y += gravity * Time.deltaTime;
            _velocity.x /= 1 + Drag.x * Time.deltaTime;
            _velocity.y /= 1 + Drag.y * Time.deltaTime;
            _velocity.z /= 1 + Drag.z * Time.deltaTime;
            _controller.Move (_velocity * Time.deltaTime);
            if (_controller.isGrounded)
                _velocity.y = 0;

            Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
            _controller.Move (move * Time.deltaTime * Speed);
            if (move != Vector3.zero) {
                transform.forward = move;
                player.GetAnimator ().SetBool ("IsWalking", true);
            } else {
                player.GetAnimator ().SetBool ("IsWalking", false);
            }
        }
    }
    public void SetButtonClicked (bool a) {
        buttonClicked = a;
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
    public bool IsAttacking () {
        return isAttacking;
    }
}