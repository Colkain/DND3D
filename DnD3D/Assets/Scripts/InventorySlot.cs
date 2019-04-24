using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour {
    private Item item;
    public Image icon;
    public Button removeButton;
    public void AddItem (Item newItem) {
        item = newItem;
        icon.sprite = item.GetIcon ();
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot () {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton () {
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().RemoveItem (item);
    }
}