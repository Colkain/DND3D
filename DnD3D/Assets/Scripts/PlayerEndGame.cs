using UnityEngine;
using UnityEngine.UI;

public class PlayerEndGame : MonoBehaviour {
    public Image icon;
    public Text nameE;
    public void AddPlayer (Character player) {
        gameObject.SetActive (true);
        nameE.text = player.GetName ();
    }
    public void ClearSlot () {
        gameObject.SetActive (false);
    }
}