using UnityEngine;
using UnityEngine.UI;
public class InvetorySlot : MonoBehaviour {
    Item item;
    public Image icon;
    public void AddItem (Item newItem) {
        item = newItem;

        icon.sprite = item.GetIcon();
        icon.enabled = true;
    }
}