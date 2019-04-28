using UnityEngine;

public class PlayersUI : MonoBehaviour {
    PlayerSlot[] slots;
    void Start () {
        slots = transform.GetComponentsInChildren<PlayerSlot> ();
    }
    public void SetUI (GameboardControl gameboard) {
        for (int i = 0; i < slots.Length; i++) {
            if (i < gameboard.GetCMax ()) {
                slots[i].AddPlayer (gameboard.GetCharacter (i));
            } else
                slots[i].ClearSlot ();
        }
    }
}