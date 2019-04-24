using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour {
    private Item item;
    public Image icon;
    public Button itemButton;
    public Button removeButton;
    void Update () {
        if (item != null) {
            if (!GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().GetReqI (item))
                itemButton.image.color = Color.red;
            else if (item.GetEquipped ())
                itemButton.image.color = Color.green;
            else
                itemButton.image.color = Color.white;
        }
    }
    public void AddItem (Item newItem) {
        item = newItem;
        icon.sprite = item.GetIcon ();
        icon.enabled = true;
        itemButton.interactable = true;
        removeButton.interactable = true;
    }
    public void ClearSlot () {
        item = null;

        itemButton.image.color = Color.white;
        icon.sprite = null;
        icon.enabled = false;
        itemButton.interactable = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton () {
        if ((item.GetTypeI () == "Equipment") && (item.GetEquipped ())) {
            GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().UnequipItem (item);
        }
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().RemoveItem (item);
    }
    public void OnItemButton () {
        if (item.GetTypeI () == "Equipment") {
            if (!item.GetEquipped ())
                GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().EquipItem (item);
            else
                GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().UnequipItem (item);
        } else {
            GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().UseItem (item);
            OnRemoveButton ();
        }
    }
}