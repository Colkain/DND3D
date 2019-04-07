using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    private bool _action = true;
    //Mouvement
    GameboardControl gameboard;
    public float Speed = 4f;
    public float gravity = -9.81f;
    public Vector3 Drag;
    private CharacterController _controller;
    private Vector3 _velocity;
    //Attack
    public static List<Tile> cells;

    public Color startColor;
    public Color endColor;
    // Start is called before the first frame update
    void Start () {
        _controller = GetComponent<CharacterController> ();
        gameboard = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
        _action = true;
    }
    // Update is called once per frame
    void Update () {
        if (IsTurn ()) {
            //Mouvement
            Move ();
            //Attack
            if (Input.GetKey (KeyCode.Space)) {
                _action = false;
                StartCoroutine (Attack ());
            }

        }
    }
    public void Move () {
        if (_action) {
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
    }
    bool IsTurn () {
        Character c = gameObject.GetComponent<Character> ();
        int id = c.GetId ();
        int idc = gameboard.GetIdc ();
        if (id == idc)
            return true;
        else
            return false;
    }
    IEnumerator Attack () {
        cells = new List<Tile> ();
        Character c = gameObject.GetComponent<Character> ();
        int range = c.GetRange ();
        GameboardControl gb = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();
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
        while (!Input.GetKeyDown (KeyCode.Return))
            yield return null;
        foreach (Tile t in cells) {
            if (t != null)
                t.GetComponent<Renderer> ().material.color = startColor;
        }
        _action = true;
    }
}