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
            name = "Berserk";
            cooldown = 3;
            duration = 1;
        } else if (id == 1) {
            name = "Sprint";
            cooldown = 3;
            duration = 1;
        } else if (id == 2) {
            name = "Snipe";
            cooldown = 3;
            duration = 1;
        } else if (id == 3) {
            name = "Heal";
            cooldown = 3;
            duration = 1;
        } else if (id == 4) {
            name = "Damage";
            cooldown = 3;
            duration = 1;
        } else if (id == 5) {
            name = "Block";
            cooldown = 3;
        } else if (id == 6) {
            name = "Refresh";
            duration = 1;
        } else if (id == 7) {
            name = "Limit Break: Damage";
            cooldown = 0;
            duration = 1;
        } else if (id == 8) {
            name = "Limit Break: Movement";
            cooldown = 0;
            duration = 1;
        } else if (id == 9) {
            name = "Limit Break: Action";
            cooldown = 0;
            duration = 1;
        } else if (id == 10) {
            name = "Adventurer: Reckless";
            passive = true;
        } else if (id == 11) {
            name = "Adventurer: Careful";
            passive = true;
        } else if (id == 12) {
            name = "Explorer: Careful";
            passive = true;
        } else if (id == 13) {
            name = "Explorer: Impatient";
            passive = true;
        } else if (id == 14) {
            name = "Vampire";
            passive = true;
        } else if (id == 15) {
            name = "Leech";
            passive = true;
        } else if (id == 16) {
            name = "Investigator: Action";
            cooldown = 3;
        } else if (id == 17) {
            name = "Investigator: Movement";
            cooldown = 2;
        } else if (id == 18) {
            name = "Investigator: Health";
            cooldown = 2;
        } else if (id == 19) {
            name = "Investigator: Damage";
            cooldown = 2;
        } else if (id == 20) {
            name = "Investigator: Max Health";
            cooldown = 3;
        }
        SetPower ();
        icon = Resources.Load<Sprite> (name);
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public void SetPower () {
        string d="";
        if (id == 0) {
            intensity = level;
            d = "+" + intensity + " Action.";
        } else if (id == 1) {
            intensity = level;
            d = "+" + intensity + " Movement.";
        } else if (id == 2) {
            intensity = level;
            d = "+" + intensity + " Range.";
        } else if (id == 3) {
            intensity = 2 + level;
            d = "Can Heal: " + level + ";" + intensity;
        } else if (id == 4) {
            intensity = 1 + level;
            d = "+" + intensity + " bonus damage.";
        } else if (id == 5) {
            duration = level;
            d = "Prevent damage for " + duration + " turns.";
        } else if (id == 6) {
            d = "Reset power cooldowns.";
            cooldown = 6 - level;
        } else if (id == 7) {
            intensity = 5 - level;
            if (intensity == 0)
                intensity++;
            d = "Decrease your health by " + intensity + " yourself and increase your damage by 1.";
        } else if (id == 8) {
            intensity = 5 - level;
            if (intensity == 0)
                intensity++;
            d = "Decrease your health by " + intensity + " yourself and increase your movement by 1.";
        } else if (id == 9) {
            intensity = 6 - level;
            if (intensity == 1)
                intensity++;
            d = "Decrease your health by " + intensity + " yourself and gain 1 action.";
        } else if (id == 10) {
            intensity = level;
            d = "Deal " + intensity + " damage to everyone in the tile you are entering.";
        } else if (id == 11) {
            intensity = level;
            d = "Gain " + intensity + " health when entering a tile.";
        } else if (id == 12) {
            intensity = level;
            d = "Gain " + intensity + " health when exploring a new tile.";
        } else if (id == 13) {
            intensity = level;
            d = "Gain " + intensity + " movement when exploring a new tile.";
        } else if (id == 14) {
            intensity = level;
            d = "Gain " + intensity + " health when attacking.";
        } else if (id == 15) {
            intensity = 10 * level;
            if (intensity > 100)
                intensity = 100;
            d = "Gain health equal to " + intensity + "% of your damage when attacking.";
        } else if (id == 16) {
            intensity = level;
            d = "Gain " + intensity + " action when checking a new tile";
        } else if (id == 17) {
            intensity = level;
            d = "Gain " + intensity + " movement when checking a new tile";
        } else if (id == 18) {
            intensity = level;
            d = "Gain " + intensity + " health when checking a new tile";
        } else if (id == 19) {
            intensity = level;
            d = "Gain " + intensity + " damage when checking a new tile";
        } else if (id == 20) {
            intensity = level;
            d = "Gain " + intensity + " max health when checking a new tile";
        }
        description = "lv." + level + "\t CD:" + cooldown + "\n" + d;
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
        SetPower ();
    }
    public int GetDuration () => duration;
    public Sprite GetIcon () => icon;
}