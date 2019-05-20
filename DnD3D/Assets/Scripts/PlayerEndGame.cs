using UnityEngine;
using UnityEngine.UI;

public class PlayerEndGame : MonoBehaviour {
    public Image icon;
    public Text nameE;
    public void AddPlayer (Character player) {
        gameObject.SetActive (true);
        nameE.text = player.GetName ();
        icon.sprite = Resources.Load<Sprite> (player.GetClass ());
    }
    public void ClearSlot () {
        gameObject.SetActive (false);
    }
}