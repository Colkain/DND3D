using UnityEngine;

[System.Serializable]
public class Power {
    [SerializeField] private int id;
    [SerializeField] private int level;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int cooldown;
    [SerializeField] private int cooldownUI;
    [SerializeField] private Sprite icon;
    public Power (int i) {
        id = i;
        level = 1;
        cooldownUI = 0;
        if (id == 0) {
            name = "Berserk";
            description = "+1 Action.";
            cooldown = 3;
        } else if (id == 1) {
            name = "Sprint";
            description = "+2 Mouvement.";
            cooldown = 3;
        } else if (id == 2) {
            name = "Snipe";
            description = "Range +1.";
            cooldown = 3;
        } else if (id == 3) {
            name = "Heal";
            description = "Can Heal : 1;5";
            cooldown = 3;
        } else if (id == 4) {
            name = "Damage";
            description = "+1 bonus damage.";
            cooldown = 3;
        } else if (id == 5) {
            name = "Block";
            description = "Prevent next damage.";
            cooldown = 3;
        }
        icon = Resources.Load<Sprite> (name);
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetId () => id;
    public int GetCooldown () => cooldown;
    public void SetCooldownUI (int i) {
        cooldownUI += i;
    }
    public int GetCooldownUI () => cooldownUI;
    public int GetLevel () => level;
    public void SetLevel (int i) {
        level += i;
    }
    public Sprite GetIcon () => icon;
}