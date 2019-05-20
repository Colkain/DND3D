using UnityEngine;

[System.Serializable]
public class Power {
    [SerializeField] private int id;
    [SerializeField] private int level;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int intensity;
    [SerializeField] private int duration;
    [SerializeField] private int cooldown;
    [SerializeField] private int cooldownUI;
    [SerializeField] private bool passive = false;
    [SerializeField] private Sprite icon;
    public Power (int i) {
        id = i;
        level = 1;
        cooldownUI = 0;
        if (id == 0) {
            intensity = level;
            name = "Berserk";
            description = "+" + intensity + " Action.";
            cooldown = 3;
            duration = 1;
        } else if (id == 1) {
            intensity = level;
            name = "Sprint";
            description = "+" + intensity + " Movement.";
            cooldown = 3;
            duration = 1;
        } else if (id == 2) {
            intensity = level;
            name = "Snipe";
            description = "+" + intensity + " Range.";
            cooldown = 3;
            duration = 1;
        } else if (id == 3) {
            intensity = 2 + level;
            name = "Heal";
            description = "Can Heal: " + level + ";" + intensity;
            cooldown = 3;
            duration = 1;
        } else if (id == 4) {
            intensity = 1 + level;
            name = "Damage";
            description = "+" + intensity + " bonus damage.";
            cooldown = 3;
            duration = 1;
        } else if (id == 5) {
            name = "Block";
            duration = level;
            description = "Prevent damage for " + duration + " turns.";
            cooldown = 3;
        } else if (id == 6) {
            name = "Refresh";
            description = "Reset power cooldowns.";
            cooldown = 6 - level;
            duration = 1;
        } else if (id == 7) {
            intensity = 5 - level;
            if (intensity == 0)
                intensity++;
            name = "Limit Break: Damage";
            description = "Decrease your health by " + intensity + " yourself and increase your damage by 1.";
            cooldown = 0;
            duration = 1;
        } else if (id == 8) {
            name = "Limit Break: Movement";
            intensity = 5 - level;
            if (intensity == 0)
                intensity++;
            description = "Decrease your health by " + intensity + " yourself and increase your movement by 1.";
            cooldown = 0;
            duration = 1;
        } else if (id == 9) {
            name = "Limit Break: Action";
            intensity = 6 - level;
            if (intensity == 1)
                intensity++;
            description = "Decrease your health by " + intensity + " yourself and gain 1 action.";
            cooldown = 0;
            duration = 1;
        } else if (id == 10) {
            intensity = level;
            name = "Adventurer: Reckless";
            description = "Deal " + intensity + " damage to everyone in the tile you are entering.";
            passive = true;
        } else if (id == 11) {
            intensity = level;
            name = "Adventurer: Careful";
            description = "Gain " + intensity + " health when entering a tile.";
            passive = true;
        } else if (id == 12) {
            intensity = level;
            name = "Explorer: Careful";
            description = "Gain " + intensity + " health when exploring a new tile.";
            passive = true;
        } else if (id == 13) {
            intensity = level;
            name = "Explorer: Impatient";
            description = "Gain " + intensity + " movement when exploring a new tile.";
            passive = true;
        } else if (id == 14) {
            intensity = level;
            name = "Vampire";
            description = "Gain " + intensity + " health when attacking.";
            passive = true;
        } else if (id == 15) {
            name = "Leech";
            intensity = 10 * level;
            if (intensity > 100)
                intensity = 100;
            description = "Gain health equal to " + intensity + "% of your damage when attacking.";
            passive = true;
        } else if (id == 16) {
            intensity = level;
            name = "Investigator: Action";
            description = "Gain " + intensity + " action when checking a new tile";
            cooldown = 3;
        } else if (id == 17) {
            intensity = level;
            name = "Investigator: Movement";
            description = "Gain " + intensity + " movement when checking a new tile";
            cooldown = 2;
        } else if (id == 18) {
            intensity = level;
            name = "Investigator: Health";
            description = "Gain " + intensity + " health when checking a new tile";
            cooldown = 2;
        } else if (id == 19) {
            intensity = level;
            name = "Investigator: Damage";
            description = "Gain " + intensity + " damage when checking a new tile";
            cooldown = 2;
        } else if (id == 20) {
            intensity = level;
            name = "Investigator: Max Health";
            description = "Gain " + intensity + " max health when checking a new tile";
            cooldown = 3;
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
    public int GetIntensity () => intensity;
    public void SetIntensity (int i) {
        intensity += i;
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