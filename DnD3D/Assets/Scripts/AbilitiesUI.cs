using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour {
    private Character player = null;
    public Transform abilitiesParent;
    public Button attackButton;
    public Button checkButton;
    public Button endTurn;
    AbilitySlot[] slots;
    void Start () {
        slots = abilitiesParent.GetComponentsInChildren<AbilitySlot> ();
    }
    void Update () {
        if (player != null) {
            if (player.GetActionUI () > 0) {
                attackButton.interactable = true;
                checkButton.interactable = true;
                attackButton.image.color = Color.white;
                checkButton.image.color = Color.white;
            } else {
                attackButton.interactable = false;
                checkButton.interactable = false;
                attackButton.image.color = Color.red;
                checkButton.image.color = Color.red;
            }
            for (int i = 0; i < slots.Length; i++) {
                if (i < player.GetPowers ().Count) {
                    slots[i].AddPower (player.GetPower (i));
                } else
                    slots[i].ClearSlot ();
            }
        }
    }
    public void OnAttack () {
        player.GetComponent<CharacterMovement> ().SetButtonClicked (true);
        player.GetComponent<CharacterMovement> ().Attack ();
    }
    public void OnCheck () {
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().Check ();
    }
    public void OnEndTurn () {
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().NextTurn ();
    }
    public void SetPlayer (Character p) {
        player = p;
    }
}