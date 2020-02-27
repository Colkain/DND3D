using UnityEngine;

public class TileEvent : MonoBehaviour {
    [SerializeField] private string nameE;
    [SerializeField] private string description;
    [SerializeField] private string type;
    [SerializeField] private Power power;
    [SerializeField] private Item item;
    [SerializeField] private Hap hap;
    public void SetTileEvent (int i) {
        if (i == 1 && i < 3) {
            type = "Power";
            power = new Power (Random.Range (0, 10));
            nameE = "New power:" + power.GetName ();
            description = power.GetDescription ();
        } else if (i >= 3 && i < 5) {
            type = "Item";
            item = new Item (Random.Range (0, 18));
            nameE = "New item:" + item.GetName ();
            description = item.GetDescription ();
        } else if (i >= 5 && i < 8) {
            type = "Event";
            hap = new Hap (Random.Range (0, 4));
            nameE = "New event:+" + hap.GetName ();
            description = hap.GetDescription ();
        } else {
            type = "Void";
            nameE = "Void";
            description = "Nothing happens, it's a normal tile.";
        }
    }
    public void ClearEvent () {
        type = "Checked";
        power = null;
        item = null;
        hap = null;
        nameE = "Tile Already checked";
        description = "Too late, someone already looted the place.";
    }
    public Power GetPower () => power;
    public Item GetItem () => item;
    public Hap GetHap () => hap;
    public string GetTType () => type;
    public string GetNameE () => nameE;
    public string GetDescription () => description;
}