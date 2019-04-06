using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    Vector3 newPos;
    Vector3 offset;
    [Range (0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    private Vector3 rot;

    // Use this for initialization
    void Start () {
        offset = new Vector3 (0, 11, -6);
    }

    public void SetCamera (int idc) {
        string name = "Player" + idc;
        player = GameObject.FindWithTag (name);
        newPos = player.transform.position + offset;
        transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor);
    }
}