using UnityEngine;

[System.Serializable]
public class Hap {
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int diceRoll;
    public Hap (int i) {
        int id = i;
        if (id == 0) {
            name = "Respec";
            diceRoll = Random.Range (0, 6);
            description = "Respec a stat";
        } else if (id == 1) {
            name = "Drink";
            diceRoll = Random.Range (0, 6);
            description = "Heal up to 3hp or get hurt up to 3hp";
            if (diceRoll > 2) {
                //heal 1-3 hp
            } else {
                //damage 1-3 hp
            }
        } else if (id == 2) {
            name = "Curse";
            diceRoll = Random.Range (0, 6);
            description = "Deal 1damage to everyone else or get hurt up to 3hp";
            if (diceRoll > 2) {
                //damage others 1 hp
            } else {
                //damage 1-3 hp
            }
        } else {
            name = "Level up";
            description = "Get a level";
            //level up
        }
    }
    public string GetName () => name;
    public string GetDescription () => description;
}