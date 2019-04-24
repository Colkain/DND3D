using UnityEngine;
using UnityEngine.UI;

public class StatSlot : MonoBehaviour {
    public Button levelUpButton;
    public Text text;
    public void SetText (Text t, bool i) {
        text = t;
        if (!i)
            levelUpButton.enabled = false;
    }
    void Update () { }
}