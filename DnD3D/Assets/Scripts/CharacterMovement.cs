using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    private bool _isTurn = false;
    GameboardControl gameboard;
    public float Speed = 4f;
    public float gravity = -9.81f;
    public Vector3 Drag;
    private CharacterController _controller;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start () {
        _controller = GetComponent<CharacterController> ();
        gameboard = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<GameboardControl> ();

    }
    // Update is called once per frame
    void Update () {
        if (IsTurn ()) {
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

    public void SetTurn (bool t) {
        _isTurn = t;
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
}