using UnityEngine;

public class TileEvent : MonoBehaviour {
    [SerializeField] private int id;
    [SerializeField] private string nameE;
    [SerializeField] private string description;
    [SerializeField] private Power power;
    [SerializeField] private Item item;
    [SerializeField] private Hap hap;
    public void SetTileEvent (int i) {
        id = i;
        if (id == 0) {
            power = new Power (Random.Range (0, 6));
            nameE = "New power:" + power.GetName ();
            description = power.GetDescription ();
        } else if (id == 1) {
            item = new Item (Random.Range (0, 18));
            nameE = "New item:" + item.GetName ();
            description = item.GetDescription ();
        } else if (id == 2) {
            hap = new Hap (Random.Range (0, 4));
            nameE = "New event:+" + hap.GetName ();
            description = hap.GetDescription ();
        } else {
            nameE = "Void";
            description = "Nothing happens, it's a normal tile.";
        }
    }
    public void ClearEvent () {
        id = 3;
        power = null;
        item = null;
        hap = null;
        nameE = "Tile Already checked";
        description = "Too late, someone already looted the place.";
    }
    public Power GetPower () => power;
    public Item GetItem () => item;
    public Hap GetHap () => hap;
    public int GetId () => id;
    public string GetNameE () => nameE;
    public string GetDescription () => description;
}