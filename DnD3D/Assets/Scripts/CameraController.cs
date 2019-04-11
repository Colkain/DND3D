using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    Vector3 newPos;
    Vector3[] offsets;
    Quaternion[] angles;
    float smoothFactor = 0.5f;
    bool isSet = false;
    [SerializeField] bool isLocked = true;
    int whatOffset;

    void Start () {
        offsets = new Vector3[3];
        angles = new Quaternion[3];
        offsets[0] = new Vector3 (0, 8, -3);
        angles[0] = Quaternion.Euler (50, 0, 0);
        offsets[1] = new Vector3 (0, 11, -6);
        angles[1] = Quaternion.Euler (60, 0, 0);
        offsets[2] = new Vector3 (0, 30, 0);
        angles[2] = Quaternion.Euler (90, 0, 0);
    }
    void Update () {
        if (isSet) {
            if (isLocked) {
                newPos = player.transform.position + offsets[whatOffset];
                transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor);
                transform.rotation = Quaternion.Slerp (transform.rotation, angles[whatOffset], smoothFactor);
            } else {
                MoveCamera ();
            }
            SetisLock ();
            ChangeView ();
        }
    }
    public void SetCamera (int idc) {
        if (!isSet)
            isSet = true;
        player = GameObject.FindWithTag ("Player" + idc);
        whatOffset = 1;
    }
    public void ChangeView () {
        if (Input.GetAxis ("Mouse ScrollWheel") > 0f) // forward
        {
            if (whatOffset > 0) {
                whatOffset--;
            }
        }
        if (Input.GetAxis ("Mouse ScrollWheel") < 0f) // backwards
        {
            if (whatOffset < offsets.Length - 1) {
                whatOffset++;
            }
        }
    }
    public void SetisLock () {
        if (Input.GetKeyUp (KeyCode.LeftControl)) {
            Debug.Log ("a");
            if (isLocked)
                isLocked = false;
            else
                isLocked = true;
        }
    }
    public void MoveCamera () {
        //Move Camera when mouse at the edge of the screen.
    }
}