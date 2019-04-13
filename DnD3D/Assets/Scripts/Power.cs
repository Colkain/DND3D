using UnityEngine;

public class Power : MonoBehaviour {
    private string nameP;
    private string description;
    private int id;
    private int cooldown;

    public Power (int i) {
        id = i;
        if (id == 0) {
            nameP = "Berserk";
            description = "+1 Action";
            cooldown = 1;
        } else if (id == 1) {
            nameP = "Backstab";
            description = "+2 Mouvement";
            cooldown = 1;
        } else if (id == 2) {
            nameP = "Sniper";
            description = "Range +1";
            cooldown = 1;
        } else if (id == 3) {
            nameP = "Heal";
            description = "Can Heal : 1;5";
            cooldown = 1;
        } else if (id == 4) {
            nameP = "Dice";
            description = "+2 for all dice rolls this turn";
            cooldown = 3;
        } else if (id == 5) {
            nameP = "Reroll";
            description = "Can reroll once this turn";
            cooldown = 3;
        } else if (id == 6) {
            nameP = "Damage";
            description = "+3 damage this turn";
            cooldown = 3;
        } else if (id == 7) {
            nameP = "Block";
            description = "Prevent damage until next turn";
            cooldown = 3;
        } else
            Debug.Log ("Power Error");
    }
    public string Name => nameP;
    public string GetDescription () => description;
    public int GetId () => id;
    public int GetCooldown () => cooldown;
}