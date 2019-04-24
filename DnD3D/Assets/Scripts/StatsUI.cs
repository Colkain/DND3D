using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {
    public Text nameC;
    public Transform statsParent;
    Character player;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    public void SetPlayer (Character p) {
        player = p;
    }
}