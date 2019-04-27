using UnityEngine;
using UnityEngine.UI;

public class Buff {
    [SerializeField] private int id;
    [SerializeField] private int level;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int duration;
    [SerializeField] private int durationUI;
    [SerializeField] private Sprite icon;
    public Buff (int i, int l, Sprite ic) {
        //effects 0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom 7:damage 8:range
        id = i;
        level = l;
        if (i == 0) {
            name = "Movement";
            description = "+" + level + " Movement.";
            duration = 1;
        } else if (i == 1) {
            name = "Max Health";
            description = "+" + level + " Max Health.";
            duration = 1;
        } else if (i == 2) {
            name = "Heal";
            description = "+" + level + " Health.";
            duration = 1;
        } else if (i == 3) {
            name = "Strength";
            description = "+" + level + " Strength.";
            duration = 1;
        } else if (i == 4) {
            name = "Agility";
            description = "+" + level + " Agility.";
            duration = 1;
        } else if (i == 5) {
            name = "Intelligence";
            description = "+" + level + " Intelligence.";
            duration = 1;
        } else if (i == 6) {
            name = "Wisdom";
            description = "+" + level + " Wisdom.";
            duration = 1;
        } else if (i == 7) {
            name = "Bonus Damage";
            description = "+" + level + " Bonus Damage.";
            duration = 1;
        } else if (i == 8) {
            name = "Range";
            description = "+" + level + " Range.";
            duration = 1;
        } else if (i == 9) {
            name = "Immune";
            description = "Prevent damage for " + level + " turns.";
            duration = 1;
        }

        icon = ic;
        durationUI = duration;
    }

    public int GetId () => id;
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetDuration () => duration;
    public int GetDurationUI () => durationUI;
    public void SetDurationUI (int i) {
        durationUI += i;
    }
    public Sprite GetIcon () => icon;
}