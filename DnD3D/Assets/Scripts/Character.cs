using UnityEngine;

public class Character : MonoBehaviour {

    public GameObject warriorPrefab;
    public GameObject roguePrefab;
    public GameObject magePrefab;
    public GameObject clericPrefab;
    private GameObject gameBoardPrefab;

    [SerializeField] private string nameC;
    [SerializeField] private string classC;
    [SerializeField] private bool isTurn;
    [SerializeField] private int id;
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private int action;
    [SerializeField] private int mouvement;
    [SerializeField] private int mouvementUI;
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int intelligence;
    [SerializeField] private int wisdom;
    [SerializeField] private int range;
    [SerializeField] private int level;
    [SerializeField] private Vector3 coor;
    [SerializeField] private Item[] items;
    [SerializeField] private Power[] powers;

    public void SetWarrior (int i, Vector3 coorc, string n) {
        items = new Item[6];
        powers = new Power[3];
        nameC = n;
        classC = "Warrior";
        isTurn = false;
        id = i;
        action = 1;
        mouvement = Random.Range (1, 5);
        maxHealth = Random.Range (5, 11);
        health = maxHealth;
        strength = Random.Range (5, 11);
        agility = Random.Range (1, 5);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (1, 4);
        range = 0;
        level = 1;
        coor = coorc;
        powers[0] = new Power (0);

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (warriorPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);

        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetRogue (int i, Vector3 coorc, string n) {
        items = new Item[6];
        powers = new Power[3];
        nameC = n;
        classC = "Rogue";
        isTurn = false;
        id = i;
        action = 1;
        mouvement = Random.Range (2, 7);
        maxHealth = Random.Range (4, 9);
        health = maxHealth;
        strength = Random.Range (1, 5);
        agility = Random.Range (5, 10);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (1, 4);
        range = 0;
        level = 1;
        coor = coorc;
        powers[0] = new Power (1);

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (roguePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);
        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetMage (int i, Vector3 coorc, string n) {
        items = new Item[6];
        powers = new Power[3];
        nameC = n;
        classC = "Mage";
        isTurn = false;
        id = i;
        action = 1;
        mouvement = Random.Range (2, 6);
        maxHealth = Random.Range (3, 9);
        health = maxHealth;
        strength = Random.Range (1, 4);
        agility = Random.Range (1, 4);
        intelligence = Random.Range (5, 11);
        wisdom = Random.Range (2, 6);
        range = 0;
        level = 1;
        coor = coorc;
        powers[0] = new Power (2);

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (magePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);
        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetCleric (int i, Vector3 coorc, string n) {
        items = new Item[6];
        powers = new Power[3];
        nameC = n;
        classC = "Cleric";
        isTurn = false;
        id = i;
        action = 1;
        mouvement = Random.Range (1, 6);
        maxHealth = Random.Range (5, 9);
        health = maxHealth;
        strength = Random.Range (1, 6);
        agility = Random.Range (1, 4);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (5, 10);
        range = 0;
        level = 1;
        coor = coorc;

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (clericPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);
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
    public int GetAction () => action;
    public void ActivatePowerEffect (Power p) {
        if (p.GetId () == 0) {
            action++;
        } else if (p.GetId () == 1) {
            mouvement += 2;
            mouvementUI += 2;
        } else if (p.GetId () == 2) {
            range++;
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