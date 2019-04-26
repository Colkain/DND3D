using UnityEngine;
using UnityEngine.UI;

public class Buff {
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int[] effects;
    [SerializeField] private int duration;
    [SerializeField] private int durationUI;
    [SerializeField] private Sprite icon;
    public Buff (int i, string n, string d, int[] e, int du, Sprite ic) {
        effects = new int[9]; //effects 0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom 7:damage 8:range
        id = i;
        name = n;
        description = d;
        effects = e;
        duration = du;
        durationUI = du;
        icon = ic;
    }
    public int GetId () => id;
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetEffect (int i) => effects[i];
    public int GetDuration () => duration;
    public int GetDurationUI () => durationUI;
    public void SetDurationUI (int i) {
        durationUI += i;
    }
    public Sprite GetIcon () => icon;
}