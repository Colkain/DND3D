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
            diceRoll = Random.Range (1, 10);
            description = "Respec a random stat (0,10).";
        } else if (id == 1) {
            name = "Drink";
            diceRoll = Random.Range (0, 6);
            description = "Heal up to 3hp or get hurt up to 2hp.";
        } else if (id == 2) {
            name = "Curse";
            diceRoll = Random.Range (0, 6);
            description = "Deal 1damage to everyone else or get hurt up to 3hp.";
        } else if (id == 3) {
            name = "Level up";
            description = "Get a level.";
        }
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public void ActivateHap (Character p) {
        if (id == 0) {
            string stat = null;
            int diceRoll2 = Random.Range (0, 6);
            if (diceRoll2 == 0) {
                stat = "Mouvement";
                p.SetMouvement (diceRoll - p.GetMouvement ());
            } else if (diceRoll2 == 1) {
                stat = "Maximum Health";
                p.SetMaxHealth (diceRoll - p.GetMaxHealth ());
                if (p.GetMaxHealth () < p.GetHealth ())
                    p.SetHealth (p.GetMaxHealth () - p.GetHealth ());
            } else if (diceRoll2 == 2) {
                stat = "Strength";
                p.SetStrength (diceRoll - p.GetStrength ());
            } else if (diceRoll2 == 3) {
                stat = "Agility";
                p.SetAgility (diceRoll - p.GetAgility ());
            } else if (diceRoll2 == 4) {
                stat = "Intelligence";
                p.SetIntelligence (diceRoll - p.GetIntelligence ());
            } else {
                stat = "Wisdom";
                p.SetWisdom (diceRoll - p.GetWisdom ());
            }
            description = "Your " + stat + " has been set to " + diceRoll + ".";
        } else if (id == 1) {
            if (diceRoll < 3) {
                p.SetHealth (diceRoll);
                description = "You won the bet, you gain " + diceRoll + " HP.";
            } else {
                int d = diceRoll - 2;
                p.SetHealth (-d);
                description = "You lost the bet, you lost " + d + " HP.";
            }
        } else if (id == 2) {
            if (diceRoll < 3) {
                p.SetHealth (diceRoll);
                description = "You lost the bet, you lost " + diceRoll + " HP.";
            } else {
                GameboardControl gb = GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ();
                foreach (Character c in gb.GetCharacters ()) {
                    if (c.GetId () != p.GetId ())
                        c.SetHealth (-1);
                }
                description = "You won the bet, everyone else loses 1 Hp.";
            }
        } else if (id == 3) {
            UIController uiC = GameObject.Find ("Canvas").GetComponent<UIController> ();
            uiC.SetLevelUpButtons (true);
            description = "You gain a level.";
        }
    }
}