using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public GameObject warriorModel;
    public GameObject rogueModel;
    public GameObject mageModel;
    public GameObject clericModel;
    GameObject characterModel;
    private GameObject gameBoard;
    private Animator animator;
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
    [SerializeField] private int level;
    [SerializeField] private int bonusAttack;
    [SerializeField] private bool immune;
    [SerializeField] private bool isAlive;
    [SerializeField] private Vector3 coor;
    [SerializeField] private List<Power> powers;
    [SerializeField] private List<Item> items;
    [SerializeField] private List<Buff> buffs;
    void Awake () {
        gameBoard = GameObject.FindWithTag ("GameBoard");
    }
    void Update () {
        if (isTurn) {
            for (int i = 0; i < buffs.Count; i++) {
                if (buffs[i].GetDuration () == 0) {
                    ActivateBuff (buffs[i], -1);
                    buffs.RemoveAt (i);
                }
            }
            if (mouvementUI <= 0)
                gameBoard.GetComponent<GameboardControl> ().ActivateDoors (-0.1f);
            else
                gameBoard.GetComponent<GameboardControl> ().ActivateDoors (-1);
            if (!isAlive)
                GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().NextTurn ();
        }
    }
    public void SetCharacter (string classId, int i, Vector3 coorc, string n) {
        nameC = n;
        classC = classId;
        isTurn = false;
        id = i;
        action = 1;
        range = 0;
        level = 1;
        bonusAttack = 0;
        immune = false;
        isAlive = true;
        coor = coorc;
        powers = new List<Power> ();
        items = new List<Item> ();
        buffs = new List<Buff> ();

        Character charObject = Instantiate (this, coorc, Quaternion.identity);
        gameBoard = GameObject.FindWithTag ("GameBoard");
        charObject.transform.SetParent (gameBoard.transform, false);

        charObject.name = ("Player" + id);
        charObject.tag = ("Player" + id);
    }
    public void SetClass () {

        if (classC == "Warrior") {
            mouvement = Random.Range (1, 5);
            maxHealth = Random.Range (5, 11);
            strength = Random.Range (5, 11);
            agility = Random.Range (1, 5);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            characterModel = Instantiate (warriorModel, transform.position, Quaternion.identity);
        } else if (classC == "Rogue") {
            mouvement = Random.Range (2, 7);
            maxHealth = Random.Range (4, 9);
            strength = Random.Range (1, 5);
            agility = Random.Range (5, 10);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (1, 4);
            characterModel = Instantiate (rogueModel, transform.position, Quaternion.identity);
        } else if (classC == "Mage") {
            mouvement = Random.Range (2, 6);
            maxHealth = Random.Range (3, 9);
            strength = Random.Range (1, 4);
            agility = Random.Range (1, 4);
            intelligence = Random.Range (5, 10);
            wisdom = Random.Range (2, 6);
            characterModel = Instantiate (mageModel, transform.position, Quaternion.identity);
        } else if (classC == "Cleric") {
            mouvement = Random.Range (1, 6);
            maxHealth = Random.Range (5, 9);
            strength = Random.Range (1, 6);
            agility = Random.Range (1, 4);
            intelligence = Random.Range (1, 4);
            wisdom = Random.Range (5, 11);
            characterModel = Instantiate (clericModel, transform.position, Quaternion.identity);
        }

        characterModel.transform.SetParent (transform);
        characterModel.transform.localScale = new Vector3 (1, 1, 1);
        animator = characterModel.GetComponent<Animator> ();
        actionUI = action;
        mouvementUI = mouvement;
        health = maxHealth;
    }
    public string GetName () => nameC;
    public string GetClass () => classC;
    public int GetHealth () => health;
    public void SetHealth (int h) {
        if (health > 0) {
            if (immune && h < 0)
                return;
            else {
                if (h < 0)
                    GetAnimator ().SetBool ("IsHit", true);

                health += h;
            }
            if (health <= 0) {
                health = 0;
                isAlive = false;
                GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().SetDedCharacters ();
                GetAnimator ().SetBool ("IsAlive", false);
            }
        }
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
    public void SetStrength (int i) {
        strength += i;
    }
    public void SetAgility (int i) {
        agility += i;
    }
    public void SetIntelligence (int i) {
        intelligence += i;
    }
    public void SetWisdom (int i) {
        wisdom += i;
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
        return (int) (strength + intelligence + agility + wisdom) / 8 + bonusAttack; //returns damage
    }
    public bool GetisTurn () => isTurn;
    public void SetisTurn (bool t) {
        GetAnimator ().SetBool ("IsWalking", false);
        isTurn = t;
    }
    public void SetActionUI (int i) {
        actionUI += i;
    }
    public int GetAction () => action;
    public int GetActionUI () => actionUI;
    public void EquipItem (Item item) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i] == item) {
                if (GetReqI (items[i])) {
                    ActivateEffect (items[i]);
                    items[i].SetEquiped (true);
                    return;
                }
            }
        }
    }
    public void UnequipItem (Item item) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i] == item) {
                RemoveBuff (item);
                items[i].SetEquiped (false);
                return;
            }
        }
    }
    public void UseItem (Item item) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i] == item) {
                ActivatePotion (items[i]);
                return;
            }
        }
    }
    public void ActivatePotion (Item item) {
        mouvement += item.GetEffect (0);
        mouvementUI += item.GetEffect (0);
        maxHealth += item.GetEffect (1);
        health += item.GetEffect (1);
        health += item.GetEffect (2);
        if (health > maxHealth)
            health = maxHealth;
        strength += item.GetEffect (3);
        agility += item.GetEffect (4);
        intelligence += item.GetEffect (5);
        wisdom += item.GetEffect (6);
        bonusAttack += item.GetEffect (7);
        range += item.GetEffect (8);
    }
    public void ActivateBuff (Buff b, int polarity) {
        mouvement += b.GetEffect (0) * polarity;
        mouvementUI += b.GetEffect (0) * polarity;
        maxHealth += b.GetEffect (1) * polarity;
        health += b.GetEffect (1) * polarity;
        health += b.GetEffect (2) * polarity;
        if (health > maxHealth)
            health = maxHealth;
        strength += b.GetEffect (3) * polarity;
        agility += b.GetEffect (4) * polarity;
        intelligence += b.GetEffect (5) * polarity;
        wisdom += b.GetEffect (6) * polarity;
        bonusAttack += b.GetEffect (7) * polarity;
        range += b.GetEffect (8) * polarity;
        if (b.GetEffect (9) > 0 && polarity > 0)
            immune = true;
        else if (b.GetEffect (9) > 0 && polarity < 0)
            immune = false;
        action += b.GetEffect (10) * polarity;
        actionUI += b.GetEffect (10) * polarity;
    }
    public void ActivateEffect (Item i) {
        Buff b;
        if (i.GetId () < 6)
            b = new Buff (7, i.GetEffect (7), 99, i.GetIcon ());
        else if (i.GetId () == 6 || i.GetId () == 7)
            b = new Buff (8, i.GetEffect (8), 99, i.GetIcon ());
        else if (i.GetId () == 8 || i.GetId () == 9 || i.GetId () == 10)
            b = new Buff (1, i.GetEffect (1), 99, i.GetIcon ());
        else {
            Debug.Log ("error");
            b = null;
        }
        buffs.Add (b);
        ActivateBuff (b, 1);
    }
    public void ActivateEffect (Power p) {
        if (p.GetCooldownUI () == 0) {
            if (p.GetId () == 3) {
                health += Random.Range (p.GetLevel (), (int) p.GetIntensity ());
                if (health > maxHealth)
                    health = maxHealth;
            } else if (p.GetId () == 6) {
                foreach (Power po in powers) {
                    if (po.GetId () != p.GetId ()) {
                        po.SetCooldownUI (-po.GetCooldownUI ());
                    }
                }
            } else {
                if (p.GetId () == 0)
                    AddBuff (10, p.GetIntensity (), p.GetDuration (), p.GetIcon ());
                else if (p.GetId () == 1)
                    AddBuff (0, p.GetIntensity (), p.GetDuration (), p.GetIcon ());
                else if (p.GetId () == 2)
                    AddBuff (8, p.GetIntensity (), p.GetDuration (), p.GetIcon ());
                else if (p.GetId () == 4)
                    AddBuff (7, p.GetIntensity (), p.GetDuration (), p.GetIcon ());
                else if (p.GetId () == 5)
                    AddBuff (9, p.GetLevel (), p.GetDuration (), p.GetIcon ());
                else if (p.GetId () == 7) {
                    SetHealth (-p.GetIntensity ());
                    AddBuff (7, 1, p.GetDuration (), p.GetIcon ());
                } else if (p.GetId () == 8) {
                    SetHealth (-p.GetIntensity ());
                    AddBuff (0, 1, p.GetDuration (), p.GetIcon ());
                } else if (p.GetId () == 9) {
                    SetHealth (-p.GetIntensity ());
                    AddBuff (10, 1, p.GetDuration (), p.GetIcon ());
                }
            }
            GetAnimator ().SetTrigger ("BuffEffect");
            p.SetCooldownUI (p.GetCooldown ());
        }
    }
    public void AddBuff (int id, int intensity, int duration, Sprite icon) {
        foreach (Buff b in buffs) {
            if (b.GetId () == id && b.GetDuration () == duration) {
                ActivateBuff (b, 1);
                b.SetLevel (intensity);
                return;
            }
        }
        Buff buff = new Buff (id, intensity, duration, icon);
        buffs.Add (buff);
        ActivateBuff (buff, 1);
    }
    public void AddPower (int i) {
        powers.Add (new Power (i));
    }
    public void AddPower (Power i) {
        foreach (Power p in powers) {
            if (p.GetId () == i.GetId ()) {
                p.SetLevel (1);
                return;
            }
        }
        if (powers.Count < 3) {
            powers.Add (i);
        }
    }
    public void RemovePower (Power p) {
        for (int i = 0; i < powers.Count; i++) {
            if (powers[i] == p)
                powers.RemoveAt (i);
        }
    }

    public Power GetPower (int i) {
        if (powers.Count >= i + 1)
            return powers[i];
        else
            return null;
    }
    public void AddItem (Item i) {
        if (items.Count < 6)
            items.Add (i);
    }
    public void RemoveItem (Item item) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i] == item)
                items.RemoveAt (i);
        }
    }
    public void SetbuffsdurationUI () {
        for (int i = 0; i < buffs.Count; i++) {
            buffs[i].SetDuration (-1);
        }
    }
    public void RemoveBuff (Item a) {
        int e;
        if (a.GetId () < 6)
            e = 7;
        else if (a.GetId () == 6 || a.GetId () == 7)
            e = 8;
        else
            e = 1;

        for (int i = 0; i < buffs.Count; i++) {
            if (buffs[i].GetEffect (buffs[i].GetId ()) == a.GetEffect (e)) {
                ActivateBuff (buffs[i], -1);
                buffs.RemoveAt (i);
            }
        }
    }
    public List<Power> GetPowers () => powers;
    public List<Item> GetItems () => items;
    public List<Buff> GetBuffs () => buffs;
    public Item GetItem (int i) {
        if (items.Count >= i + 1)
            return items[i];
        else
            return null;
    }
    public Buff GetBuff (int i) {
        if (buffs.Count >= i + 1)
            return buffs[i];
        else
            return null;
    }
    public bool GetReqI (Item item) {
        if ((item.GetRequirement (0) <= strength) && (item.GetRequirement (1) <= agility) && (item.GetRequirement (2) <= intelligence) && (item.GetRequirement (3) <= wisdom))
            return true;
        else
            return false;
    }
    public bool GetIsAlive () => isAlive;
    public Animator GetAnimator () => animator;
}