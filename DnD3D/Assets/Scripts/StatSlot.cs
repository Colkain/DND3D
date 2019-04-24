using UnityEngine;
using UnityEngine.UI;

public class StatSlot : MonoBehaviour {
    public Button levelUpButton;
    public Text text;
    void Start () {
        levelUpButton.interactable = false;
    }
    public void SetText (string t) {
        text.text = t;
    }
    public void SetInteractable (bool i) {
            levelUpButton.interactable = i;
    }
}