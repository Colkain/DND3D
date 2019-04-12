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
    [SerializeField] private int mouvement;
    [SerializeField] private int mouvementUI;
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int intelligence;
    [SerializeField] private int wisdom;
    [SerializeField] private int range;
    [SerializeField] private string power;
    [SerializeField] private int level;
    [SerializeField] private Vector3 coor;

    public void SetWarrior (int i, Vector3 coorc, string n) {
        nameC = n;
        classC = "Warrior";
        isTurn = false;
        id = i;
        maxHealth = Random.Range (5, 11);
        health = maxHealth;
        mouvement = Random.Range (1, 5);
        strength = Random.Range (5, 11);
        agility = Random.Range (1, 5);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (1, 4);
        range = 0;
        power = "Can attack again";
        level = 1;
        coor = coorc;

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (warriorPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);

        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetRogue (int i, Vector3 coorc, string n) {
        nameC = n;
        classC = "Rogue";
        isTurn = false;
        id = i;
        maxHealth = Random.Range (4, 9);
        health = maxHealth;
        mouvement = Random.Range (2, 7);
        strength = Random.Range (1, 5);
        agility = Random.Range (5, 10);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (1, 4);
        range = 0;
        power = "If not in front of enemy, gain +5 dice roll on attack";
        level = 1;
        coor = coorc;

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (roguePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);
        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetMage (int i, Vector3 coorc, string n) {
        nameC = n;
        classC = "Mage";
        isTurn = false;
        id = i;
        maxHealth = Random.Range (3, 9);
        health = maxHealth;
        mouvement = Random.Range (2, 6);
        strength = Random.Range (1, 4);
        agility = Random.Range (1, 4);
        intelligence = Random.Range (5, 11);
        wisdom = Random.Range (2, 6);
        range = 1;
        power = "+1 Range";
        level = 1;
        coor = coorc;

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoardPrefab = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoardPrefab.transform, false);
        GameObject warriorObject = Instantiate (magePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        warriorObject.transform.SetParent (charObject.transform, false);
        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }

    public void SetCleric (int i, Vector3 coorc, string n) {
        nameC = n;
        classC = "Cleric";
        isTurn = false;
        id = i;
        maxHealth = Random.Range (5, 9);
        health = maxHealth;
        mouvement = Random.Range (1, 6);
        strength = Random.Range (1, 6);
        agility = Random.Range (1, 4);
        intelligence = Random.Range (1, 4);
        wisdom = Random.Range (5, 10);
        range = 0;
        power = "Can Heal : 1;5";
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
        health = h;
    }
    public int GetMaxHealth () => maxHealth;
    public int GetMouvement () => mouvement;
    public void SetMouvement (int i) {
        mouvement = i;
    }
    public void SetMouvementUI (int i) {
        mouvementUI = i;
    }
    public int GetMouvementUI () => mouvementUI;
    public int GetStrength () => strength;
    public int GetAgility () => agility;
    public int GetIntelligence () => intelligence;
    public int GetWisdom () => wisdom;
    public int GetLevel () => level;
    public int GetRange () => range;
    public int GetId () => id;
    public string GetPower () => power;
    public int GetAttack () {
        return (int) (strength + intelligence + agility + wisdom) / 8; //returns damage
    }
    public bool GetisTurn () => isTurn;
    public void SetisTurn (bool t) {
        isTurn = t;
    }
}