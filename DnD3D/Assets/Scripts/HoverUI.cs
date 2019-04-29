using UnityEngine;
using UnityEngine.UI;

public class HoverUI : MonoBehaviour {
    public Text title;
    public Text description;
    public void SetPosition (string t, string d) {
            title.text = t;
            description.text = d;
        
    }
}