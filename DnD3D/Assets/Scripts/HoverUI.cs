using UnityEngine;
using UnityEngine.UI;

public class HoverUI : MonoBehaviour {
    bool positioned = false;
    public Text title;
    public Text description;
    public void SetPosition (Vector3 v, Vector3 offset, string t, string d) {
        if (!positioned) {
            transform.position = v + offset;
            title.text = t;
            description.text = d;
        }
        positioned = true;
    }
    public void SetPositioned (bool l) {
        positioned = l;
    }
    public bool GetPositioned () => positioned;
}