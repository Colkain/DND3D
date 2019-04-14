using UnityEngine;

[System.Serializable]
public class Item {
    private int id;
    private string typeI;
    private string nameI;
    private int[] requirements;
    private int[] effects;
    private bool equipped;
    public Item (int i) {
        requirements = new int[4]; //reqs 0:strength 1:agility 2:intelligence 3:wisdom
        effects = new int[10]; //effects 0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom 7:all 8:damage 9:range
        equipped = false;
        id = i;
        if (id == 0) {
            typeI = "Weapon";
            nameI = "Sword";
            requirements[0] = 3;
            requirements[1] = 3;
            effects[8] = 2;
        } else if (id == 1) {
            typeI = "Weapon";
            nameI = "Dagger";
            requirements[1] = 5;
            effects[8] = 4;
        } else if (id == 2) {
            typeI = "Weapon";
            nameI = "Greatsword";
            requirements[0] = 5;
            effects[8] = 4;
        } else if (id == 3) {
            typeI = "Weapon";
            nameI = "Staff";
            requirements[2] = 5;
            effects[8] = 5;
        } else if (id == 4) {
            typeI = "Weapon";
            nameI = "Wand";
            requirements[2] = 3;
            requirements[3] = 3;
            effects[8] = 2;
        } else if (id == 5) {
            typeI = "Weapon";
            nameI = "Mace";
            requirements[3] = 5;
            effects[8] = 4;
        } else if (id == 6) {
            typeI = "Weapon";
            nameI = "Bow";
            requirements[0] = 3;
            requirements[3] = 3;
            effects[9] = 1;
        } else if (id == 7) {
            typeI = "Weapon";
            nameI = "Crossbow";
            requirements[2] = 3;
            requirements[1] = 3;
            effects[9] = 1;
        } else if (id == 8) {
            typeI = "Armor";
            nameI = "Light Armor";
            requirements[0] = 2;
            requirements[1] = 2;
            requirements[2] = 2;
            requirements[3] = 2;
            effects[1] = 2;
        } else if (id == 9) {
            typeI = "Armor";
            nameI = "Medium Armor";
            requirements[0] = 4;
            requirements[1] = 4;
            requirements[2] = 4;
            requirements[3] = 4;
            effects[1] = 4;
        } else if (id == 10) {
            typeI = "Armor";
            nameI = "Heavy Armor";
            requirements[0] = 6;
            requirements[1] = 6;
            requirements[2] = 6;
            requirements[3] = 6;
            effects[1] = 6;
        } else if (id == 11) {
            typeI = "Potion";
            nameI = "Health";
            effects[2] = 2;
        } else if (id == 12) {
            typeI = "Potion";
            nameI = "Mouvement";
            effects[0] = 2;
        } else if (id == 13) {
            typeI = "Potion";
            nameI = "Strength";
            effects[3] = 2;
        } else if (id == 14) {
            typeI = "Potion";
            nameI = "Agility";
            effects[4] = 2;
        } else if (id == 15) {
            typeI = "Potion";
            nameI = "Intelligence";
            effects[5] = 2;
        } else if (id == 16) {
            typeI = "Potion";
            nameI = "Wisdom";
            effects[6] = 2;
        } else if (id == 17) {
            typeI = "Potion";
            nameI = "All Stats";
            effects[0] = 1;
            effects[1] = 1;
            effects[2] = 1;
            effects[3] = 1;
            effects[4] = 1;
            effects[5] = 1;
            effects[6] = 1;
        } else
            Debug.Log ("Item Error " + id);
    }
    public string GetTypeI () => typeI;
    public string GetNameI () => nameI;
    public int[] GetRequirements () => requirements;
    public int[] GetEffects () => effects;
    public bool GetEquipped () => equipped;
    public void SetEquiped (bool a) {
        equipped = a;
    }
}