using UnityEngine;

public class BuffsUI : MonoBehaviour {
    private Character player = null;
    public Transform buffsParent;
    BuffSlot[] slots;
    void Awake () {
        slots = buffsParent.GetComponentsInChildren<BuffSlot> ();
    }
    void Update () {
        if (player != null) {
            for (int i = 0; i < slots.Length; i++) {
                if (i < player.GetBuffs ().Count) {
                    slots[i].AddBuff (player.GetBuff (i));
                } else
                    slots[i].ClearSlot ();
            }
        }
    }
    public void SetPlayer (Character p) {
        player = p;
    }
}