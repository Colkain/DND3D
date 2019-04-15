using UnityEngine;

public class Character : MonoBehaviour {

    public Material warriorMat;
    public Material rogueMat;
    public Material mageMat;
    public Material clericMat;
    private GameObject gameBoardPrefab;
    [SerializeField] private string nameC;
    [SerializeField] private string classC;
    [SerializeField] private bool isTurn;
    [SerializeField] private int id;
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private int action;
    [SerializeField] private int actionUI;
    [SerializeField] private int mouvement;
    [SerializeField] private int mouvementUI;
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int intelligence;
    [SerializeField] private int wisdom;
    [SerializeField] private int range;
    [SerializeField] private int rangeUI;
    [SerializeField] private int level;
    [SerializeField] private Vector3 coor;
    [SerializeField] private Power[] powers;
    [SerializeField] private Item[] items;
    public void Show () {
        // Debug.Log (power.GetName ());
    }
    public void SetCharacter (string classId, int i, Vector3 coorc, string n) {
        nameC = n;
        classC = classId;
        isTurn = false;
        id = i;
        action = 1;
        range = 0;
        rangeUI = range;
        level = 1;
        coor = coorc;
        powers = new Power[3];
        items = new Item[6];

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);

        if (classId == "Warrior") {
            mouvement = Random.Range (1, 5);
            maxHealth = Random.Range (5, 11);
            strength = Random.Range (5, 11);
            agility = Random.Range (1, 5);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            charObject.GetComponent<Renderer> ().material = warriorMat;
        } else if (classC == "Rogue") {
            mouvement = Random.Range (1, 5);
            maxHealth = Random.Range (5, 11);
            strength = Random.Range (5, 11);
            agility = Random.Range (1, 5);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            charObject.GetComponent<Renderer> ().material = rogueMat;
        } else if (classC == "Mage") {
            mouvement = Random.Range (1, 5);
            maxHealth = Random.Range (5, 11);
            strength = Random.Range (5, 11);
            agility = Random.Range (1, 5);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            charObject.GetComponent<Renderer> ().material = mageMat;
        } else if (classC == "Cleric") {
            mouvement = Random.Range (1, 5);
            maxHealth = Random.Range (5, 11);
            strength = Random.Range (5, 11);
            agility = Random.Range (1, 5);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            charObject.GetComponent<Renderer> ().material = clericMat;
        }
        actionUI = action;
        mouvementUI = mouvement;
        health = maxHealth;

        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }
    public string GetName () => nameC;
    public string GetClass () => classC;
    public int GetHealth () => health;
    public void SetHealth (int h) {
        health += h;
    }
    public void SetMaxHealth (int h) {
        maxHealth += h;
    }
    public int GetMaxHealth () => maxHealth;
    public int GetMouvement () => mouvement;
    public void SetMouvement (int i) {
        mouvement += i;
    }
    public void SetMouvementUI (int i) {
        mouvementUI += i;
    }
    public void SetRange (int i) {
        range += i;
    }
    public void SetRangeUI (int i) {
        rangeUI += i;
    }
    public int GetMouvementUI () => mouvementUI;
    public int GetStrength () => strength;
    public int GetAgility () => agility;
    public int GetIntelligence () => intelligence;
    public int GetWisdom () => wisdom;
    public int GetLevel () => level;
    public void LevelUp (int stat) {
        if (stat == 0) {
            mouvement++;
            mouvementUI++;
        } else if (stat == 1) {
            health++;
            maxHealth++;
        } else if (stat == 2)
            strength++;
        else if (stat == 3)
            agility++;
        else if (stat == 4)
            intelligence++;
        else if (stat == 5)
            wisdom++;
        level++;
    }
    public int GetRange () => range;
    public int GetRangeUI () => rangeUI;
    public int GetId () => id;
    public int GetAttack () {
        return (int) (strength + intelligence + agility + wisdom) / 8; //returns damage
    }
    public bool GetisTurn () => isTurn;
    public void SetisTurn (bool t) {
        isTurn = t;
    }
    public void SetAction (int i) {
        action += i;
    }
    public void SetActionUI (int i) {
        actionUI += i;
    }
    public int GetAction () => action;
    public int GetActionUI () => actionUI;

    public void ActivatePowerEffect (Power p) {
        if (p.GetCooldownUI () == 0) {
            p.SetCooldownUI (p.GetCooldown ());
            if (p.GetId () == 0) {
                action++;
                actionUI++;
            } else if (p.GetId () == 1) {
                mouvement += 2;
                mouvementUI += 2;
            } else if (p.GetId () == 2) {
                range++;
                rangeUI++;
            } else if (p.GetId () == 3) {
                health += Random.Range (1, 5);
                if (health > maxHealth)
                    health = maxHealth;
            } else if (p.GetId () == 4) {
                // description = "+2 for all dice rolls this turn";
            } else if (p.GetId () == 5) {
                // description = "Can reroll once this turn";
            } else if (p.GetId () == 6) {
                // description = "+3 damage this turn";
            } else if (p.GetId () == 7) {
                // description = "Prevent damage until next turn";
            } else
                Debug.Log ("Power Activate Error");
        }
    }
    public void AddPower (int i) {
        for (int a = 0; a < powers.Length; a++) {
            if (powers[a].GetSet () == false) {
                powers[a] = new Power (i);
                return;
            }
        }
    }
    public Power GetPower (int i) {
        if (powers[i].GetSet () == true)
            return powers[i];
        else
            return null;
    }
    public void AddItem (Item i) {
        for (int a = 0; a < items.Length; a++) {
            if (items[a].GetSet () == false) {
                items[a] = i;
                return;
            }
        }
    }
}