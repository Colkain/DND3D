using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviour {
    private Character player;
    public GameObject buffsUI;
    public Text nameE;
    public Text healthText;
    public Transform healthBar;
    private float health;
    void Update () {
        if (player != null) {
            healthText.text = player.GetHealth () + "/" + player.GetMaxHealth ();
            health = (float) player.GetHealth () / player.GetMaxHealth ();
            healthBar.localScale = new Vector3 (health, 1, 1);
            buffsUI.GetComponent<BuffsUI> ().SetPlayer (player);
        }
    }
    public void AddPlayer (Character newPlayer) {
        gameObject.SetActive (true);
        player = newPlayer;
        nameE.text = player.GetName ();
    }
    public void ClearSlot () {
        gameObject.SetActive (false);
    }
}