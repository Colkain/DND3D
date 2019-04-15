using UnityEngine;

public class TileEvent : MonoBehaviour {
    [SerializeField] private int id;
    [SerializeField] private string nameE;
    [SerializeField] private Power power;
    [SerializeField] private Item item;

    public void SetTileEvent (int i) {
        id = i;
        if (id == 0)
            nameE = "power";
        else if (id == 1)
            nameE = "item";
        else if (id == 2)
            nameE = "event";
        else
            nameE = "Nothing happens";
    }
    public Power GetPower () => power;
    public Item GetItem () => item;
}