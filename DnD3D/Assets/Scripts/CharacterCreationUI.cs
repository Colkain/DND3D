using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUI : MonoBehaviour {
    public GameObject hoverUI;
    public Text classC;
    public Text health;
    public Text movement;
    public Text strength;
    public Text agility;
    public Text intelligence;
    public Text wisdom;
    public Text power;
    public Image icon;
    void Start () {
        hoverUI.SetActive (false);
    }
    public void OnHoverUIEnter (string c) {
        hoverUI.SetActive (true);
        classC.text = c;
        if (c == "Warrior") {
            health.text = "Health:[5,10]";
            movement.text = "Movement:[1,4]";
            strength.text = "Strength:[5,10]";
            agility.text = "Agility:[1,4]";
            intelligence.text = "Intelligence:[1,3]";
            wisdom.text = "Wisdom:[1,3]";
            power.text = "Power:Berserk";
        } else if (c == "Rogue") {
            health.text = "Health:[4,8]";
            movement.text = "Movement:[2,6]";
            strength.text = "Strength:[1,4]";
            agility.text = "Agility:[5,9]";
            intelligence.text = "Intelligence:[1,3]";
            wisdom.text = "Wisdom:[1,3]";
            power.text = "Power:Sprint";
        } else if (c == "Mage") {
            health.text = "Health:[3,8]";
            movement.text = "Movement:[2,5]";
            strength.text = "Strength:[1,3]";
            agility.text = "Agility:[1,3]";
            intelligence.text = "Intelligence:[5,9]";
            wisdom.text = "Wisdom:[2,5]";
            power.text = "Power:Snipe";
        } else if (c == "Cleric") {
            health.text = "Health:[5,8]";
            movement.text = "Movement:[1,5]";
            strength.text = "Strength:[1,5]";
            agility.text = "Agility:[1,3]";
            intelligence.text = "Intelligence:[1,3]";
            wisdom.text = "Wisdom:[5,10]";
            power.text = "Power:Heal";
        }
        icon.sprite = Resources.Load<Sprite> (c);
    }
    public void OnHoverUIExit () {
        hoverUI.SetActive (false);
    }

}