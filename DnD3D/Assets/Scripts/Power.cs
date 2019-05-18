using UnityEngine;

[System.Serializable]
public class Power {
    [SerializeField] private int id;
    [SerializeField] private int level;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int duration;
    [SerializeField] private int cooldown;
    [SerializeField] private int cooldownUI;
    [SerializeField] private Sprite icon;
    public Power (int i) {
        id = i;
        level = 1;
        cooldownUI = 0;
        if (id == 0) {
            name = "Berserk";
            description = "+" + level + " Action.";
            cooldown = 3;
            duration = 1;
        } else if (id == 1) {
            name = "Sprint";
            description = "+" + level + " Mouvement.";
            cooldown = 3;
            duration = 1;
        } else if (id == 2) {
            name = "Snipe";
            description = "+" + level + " Range.";
            cooldown = 3;
            duration = 1;
        } else if (id == 3) {
            int ia = 2 + level;
            name = "Heal";
            description = "Can Heal: " + level + ";" + ia;
            cooldown = 3;
            duration = 1;
        } else if (id == 4) {
            name = "Damage";
            description = "+" + level + " bonus damage.";
            cooldown = 3;
            duration = 1;
        } else if (id == 5) {
            name = "Block";
            description = "Prevent damage for " + level + " turns.";
            cooldown = 3;
            duration = level;
        }
        icon = Resources.Load<Sprite> (name);
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public void SetDescription () {
        if (id == 0)
            description = "+" + level + " Action.";
        else if (id == 1)
            description = "+" + level + " Mouvement.";
        else if (id == 2)
            description = "+" + level + " Range.";
        else if (id == 3) {
            int ia = 4 + level;
            description = "Can Heal: " + level + ";" + ia;
        } else if (id == 4)
            description = "+" + level + " bonus damage.";
        else if (id == 5)
            description = "Prevent damage for " + level + " turns.";
    }
    public int GetId () => id;
    public int GetCooldown () => cooldown;
    public void SetCooldownUI (int i) {
        cooldownUI += i;
    }
    public int GetCooldownUI () => cooldownUI;
    public int GetLevel () => level;
    public void SetLevel (int i) {
        level += i;
        if (id == 5)
            duration += i;
        SetDescription ();
    }
    public int GetDuration () => duration;
    public Sprite GetIcon () => icon;
}