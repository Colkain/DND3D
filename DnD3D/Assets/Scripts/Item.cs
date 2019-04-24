using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item {
    [SerializeField] private int id;
    [SerializeField] private string typeI;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int[] requirements;
    [SerializeField] private int[] effects;
    [SerializeField] private bool equipped;
    [SerializeField] private bool checkReq = false;
    [SerializeField] private Sprite icon;
    public Item (int i) {
        requirements = new int[4]; //reqs 0:strength 1:agility 2:intelligence 3:wisdom
        effects = new int[9]; //effects 0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom 7:damage 8:range
        equipped = false;
        id = i;
        if (id == 0) {
            typeI = "Equipment";
            name = "Sword";
            requirements[0] = 3;
            requirements[1] = 3;
            effects[7] = 2;
            description = "Requirements:\n\tStrength:3\n\tAgility:3\nEffect:\n\t+2 Damage";
        } else if (id == 1) {
            typeI = "Equipment";
            name = "Dagger";
            requirements[1] = 5;
            effects[7] = 4;
            description = "Requirements:\n\tAgility:5\nEffect:\n\t+4 Damage";
        } else if (id == 2) {
            typeI = "Equipment";
            name = "Greatsword";
            requirements[0] = 5;
            effects[7] = 4;
            description = "Requirements:\n\tStrength:5\nEffect:\n\t+4 Damage";
        } else if (id == 3) {
            typeI = "Equipment";
            name = "Staff";
            requirements[2] = 5;
            effects[7] = 4;
            description = "Requirements:\n\tIntelligence:5\nEffect:\n\t+4 Damage";
        } else if (id == 4) {
            typeI = "Equipment";
            name = "Wand";
            requirements[2] = 3;
            requirements[3] = 3;
            effects[7] = 2;
            description = "Requirements:\n\tIntelligence:3\n\tWisdom:3\nEffect:\n\t+2 Damage";
        } else if (id == 5) {
            typeI = "Equipment";
            name = "Mace";
            requirements[3] = 5;
            effects[7] = 4;
            description = "Requirements:\n\tWisdom:5\nEffect:\n\t+4 Damage";
        } else if (id == 6) {
            typeI = "Equipment";
            name = "Bow";
            requirements[0] = 3;
            requirements[3] = 3;
            effects[8] = 1;
            description = "Requirements:\n\tStrength:3\n\tWisdom:3\nEffect:\n\t+2 Damage";
        } else if (id == 7) {
            typeI = "Equipment";
            name = "Crossbow";
            requirements[2] = 3;
            requirements[1] = 3;
            effects[8] = 1;
            description = "Requirements:\n\tIntelligence:3\n\tAgility:3\nEffect:\n\t+2 Damage";
        } else if (id == 8) {
            typeI = "Equipment";
            name = "Light Armor";
            requirements[0] = 2;
            requirements[1] = 2;
            requirements[2] = 2;
            requirements[3] = 2;
            effects[1] = 2;
            description = "Requirements:\n\tStrength:2\n\tAgility:2\n\tIntelligence:2\n\tWisdom:2\nEffect:\n\t+2 MaxHealth";
        } else if (id == 9) {
            typeI = "Equipment";
            name = "Medium Armor";
            requirements[0] = 4;
            requirements[1] = 4;
            requirements[2] = 4;
            requirements[3] = 4;
            effects[1] = 4;
            description = "Requirements:\n\tStrength:4\n\tAgility:4\n\tIntelligence:4\n\tWisdom:4\nEffect:\n\t+4 MaxHealth";
        } else if (id == 10) {
            typeI = "Equipment";
            name = "Heavy Armor";
            requirements[0] = 6;
            requirements[1] = 6;
            requirements[2] = 6;
            requirements[3] = 6;
            effects[1] = 6;
            description = "Requirements:\n\tStrength:6\n\tAgility:6\n\tIntelligence:6\n\tWisdom:6\nEffect:\n\t+6 MaxHealth";
        } else if (id == 11) {
            typeI = "Potion";
            name = "Health Potion";
            effects[2] = 2;
            description = "Effect:\n\t+2 Health";
        } else if (id == 12) {
            typeI = "Potion";
            name = "Mouvement Potion";
            effects[0] = 2;
            description = "Effect:\n\t+2 Mouvement";
        } else if (id == 13) {
            typeI = "Potion";
            name = "Strength Potion";
            effects[3] = 2;
            description = "Effect:\n\t+2 Strength";
        } else if (id == 14) {
            typeI = "Potion";
            name = "Agility Potion";
            effects[4] = 2;
            description = "Effect:\n\t+2 Agility";
        } else if (id == 15) {
            typeI = "Potion";
            name = "Intelligence Potion";
            effects[5] = 2;
            description = "Effect:\n\t+2 Intelligence";
        } else if (id == 16) {
            typeI = "Potion";
            name = "Wisdom Potion";
            effects[6] = 2;
            description = "Effect:\n\t+2 Wisdom";
        } else if (id == 17) {
            typeI = "Potion";
            name = "All Stats Potion";
            effects[0] = 1;
            effects[1] = 1;
            effects[2] = 1;
            effects[3] = 1;
            effects[4] = 1;
            effects[5] = 1;
            effects[6] = 1;
            description = "Effects:\n\t+2 Health\n+2 Max Health\n+2 Mouvement\n+2 Strength\n+2 Agility\n+2 Intelligence\n+2 Wisdom";
        }
        icon = Resources.Load<Sprite> (name);
    }
    public string GetTypeI () => typeI;
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetRequirement (int i) => requirements[i];
    public int GetEffect (int i) => effects[i];
    public bool GetEquipped () => equipped;
    public void SetEquiped (bool a) {
        equipped = a;
    }
    public Sprite GetIcon () => icon;
}