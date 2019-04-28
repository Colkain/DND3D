using UnityEngine;
using UnityEngine.UI;

public class BuffSlot : MonoBehaviour {
    private Buff buff;
    public Image icon;
    public void AddBuff (Buff newBuff) {
        GetComponent<Image> ().enabled = true;
        buff = newBuff;
        icon.sprite = buff.GetIcon ();
        icon.enabled = true;
    }
    public void ClearSlot () {
        buff = null;
        GetComponent<Image> ().enabled = false;
        icon.sprite = null;
        icon.enabled = false;
    }
}