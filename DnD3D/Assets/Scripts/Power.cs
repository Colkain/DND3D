using UnityEngine;

[System.Serializable]
public class Power {
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int cooldown;
    [SerializeField] private int cooldownUI;

    public Power (int i) {
        id = i;
        cooldownUI = 0;
        if (id == 0) {
            name = "Berserk";
            description = "+1 Action.";
            cooldown = 3;
        } else if (id == 1) {
            name = "Backstab";
            description = "+2 Mouvement.";
            cooldown = 3;
        } else if (id == 2) {
            name = "Sniper";
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
        } else
            Debug.Log ("Power Error " + id);
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetId () => id;
    public int GetCooldown () => cooldown;
    public void SetCooldownUI (int i) {
        cooldownUI += i;
    }
    public int GetCooldownUI () => cooldownUI;

}