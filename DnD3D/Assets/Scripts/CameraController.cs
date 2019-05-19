using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    public Vector3 newPos;
    Vector3[] offsets;
    Quaternion[] angles;
    float smoothFactor = 10;
    bool isSet = false;
    [SerializeField] bool isLocked = true;
    int whatOffset;
    float panBorderThickness = 15f;
    Vector2 panMaxLimit;
    Vector2 panMinLimit;
    void Start () {
        panMaxLimit = new Vector2 ((Parameters.columns - 1), (Parameters.rows - 1)) * 8;
        panMinLimit = new Vector2 (-1, -1) * 8;
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
                ChangeView ();
            } else {
                MoveCamera ();
            }
            SetisLock ();
            transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor * Time.deltaTime);
            transform.rotation = Quaternion.Slerp (transform.rotation, angles[whatOffset], smoothFactor * Time.deltaTime);
        }
    }
    public void SetCamera (int idc) {
        if (!isSet)
            isSet = true;
        if (!isLocked)
            isLocked = true;
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
        if (Input.GetButtonUp ("Lock")) {
            if (isLocked)
                isLocked = false;
            else
                isLocked = true;
        }
    }
    public void MoveCamera () {
        //Move Camera when mouse at the edge of the screen.
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            newPos.z += smoothFactor * Time.deltaTime;
        if (Input.mousePosition.y <= panBorderThickness)
            newPos.z -= smoothFactor * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            newPos.x += smoothFactor * Time.deltaTime;
        if (Input.mousePosition.x <= panBorderThickness)
            newPos.x -= smoothFactor * Time.deltaTime;

        newPos.x = Mathf.Clamp (newPos.x, panMinLimit.x, panMaxLimit.x);
        newPos.z = Mathf.Clamp (newPos.z, panMinLimit.y, panMaxLimit.y);
    }
}