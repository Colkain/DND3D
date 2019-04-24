using UnityEngine;

public class InventoryUI : MonoBehaviour {
    private Character player = null;
    public Transform itemsParent;
    InventorySlot[] slots;
    void Start () {
        slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
    }
    void Update () {
        if (player != null) {
            for (int i = 0; i < slots.Length; i++) {
                if (i < player.GetItems ().Count) {
                    slots[i].AddItem (player.GetItem (i));
                } else
                    slots[i].ClearSlot ();
            }
        }
    }
    public void SetPlayer (Character p) {
        player = p;
    }
}