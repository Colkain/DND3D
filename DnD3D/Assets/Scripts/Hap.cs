using UnityEngine;

[System.Serializable]
public class Hap {
    [SerializeField] private int idH;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int diceRoll;
    public Hap (int i) {
        idH = i;
        if (idH == 0) {
            name = "Respec";
            diceRoll = Random.Range (1, 10);
            description = "Respec a random stat (1,10).";
        } else if (idH == 1) {
            name = "Drink";
            diceRoll = Random.Range (1, 7);
            description = "Heal up to 3hp or get hurt up to 2hp.";
        } else if (idH == 2) {
            name = "Curse";
            diceRoll = Random.Range (1, 7);
            description = "Deal 1 damage to everyone else or get hurt up to 3hp.";
        } else if (idH == 3) {
            name = "Level up";
            description = "Get a level.";
        }
    }
    public string GetName () => name;
    public string GetDescription () => description;
    public void ActivateHap (Character p) {
        if (idH == 0) {
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
        } else if (idH == 1) {
            if (diceRoll < 4) {
                p.SetHealth (diceRoll);
                if (p.GetHealth () > p.GetMaxHealth ())
                    p.SetHealth (p.GetMaxHealth () - p.GetHealth ());
                description = "You won the bet, you gain " + diceRoll + " HP.";
            } else {
                int d = diceRoll - 2;
                p.SetHealth (-d);
                description = "You lost the bet, you lost " + d + " HP.";
            }
        } else if (idH == 2) {
            if (diceRoll < 4) {
                p.SetHealth (-diceRoll);
                description = "You lost the bet, you lost " + diceRoll + " HP.";
            } else {
                GameboardControl gb = GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ();
                foreach (Character c in gb.GetCharacters ()) {
                    if (c.GetId () != p.GetId ())
                        c.SetHealth (-1);
                }
                description = "You won the bet, everyone else loses 1 Hp.";
            }
        } else {
            UIController uiC = GameObject.Find ("Canvas").GetComponent<UIController> ();
            uiC.SetLevelUpButtons (true);
            description = "You gain a level.";
        }
    }
}