using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {
    public Text nameC;
    public Transform statsParent;
    StatSlot[] slots;
    Character player = null;
    string text;
    // Start is called before the first frame update
    void Start () {
        slots = statsParent.GetComponentsInChildren<StatSlot> ();
    }

    // Update is called once per frame
    void Update () {
        if (player != null) {
            slots[1].SetText ("Lvl:" + player.GetLevel ().ToString ());
            slots[2].SetText ("Action:" + player.GetActionUI ());
            slots[3].SetText ("Range:" + player.GetRangeUI ().ToString ());
            slots[4].SetText ("Health:" + player.GetHealth ().ToString () + "/" + player.GetMaxHealth ().ToString ());
            slots[5].SetText ("Movement:" + player.GetMouvementUI ().ToString ());
            slots[6].SetText ("Strength:" + player.GetStrength ().ToString ());
            slots[7].SetText ("Agility:" + player.GetAgility ().ToString ());
            slots[8].SetText ("Intelligence:" + player.GetIntelligence ().ToString ());
            slots[9].SetText ("Wisdom:" + player.GetWisdom ().ToString ());
        }
    }
    public void SetPlayer (Character p, int r) {
        player = p;
        nameC.text = player.GetName ();
        slots[0].SetText ("Class:" + player.GetClass ());
        slots[1].SetText ("Lvl:" + player.GetLevel ().ToString ());
        slots[2].SetText ("Action:" + player.GetActionUI ());
        slots[3].SetText ("Range:" + player.GetRangeUI ().ToString ());
        slots[4].SetText ("Health:" + player.GetHealth ().ToString () + "/" + player.GetMaxHealth ().ToString ());
        slots[5].SetText ("Movement:" + player.GetMouvementUI ().ToString ());
        slots[6].SetText ("Strength:" + player.GetStrength ().ToString ());
        slots[7].SetText ("Agility:" + player.GetAgility ().ToString ());
        slots[8].SetText ("Intelligence:" + player.GetIntelligence ().ToString ());
        slots[9].SetText ("Wisdom:" + player.GetWisdom ().ToString ());
        if (r == 1)
            SetLevelUpButtons (false);
        else
            SetLevelUpButtons (true);
 }
    public void SetLevelUpButtons (bool a) {
        slots[4].SetInteractable (true);
        slots[5].SetInteractable (true);
        slots[6].SetInteractable (true);
        slots[7].SetInteractable (true);
        slots[8].SetInteractable (true);
        slots[9].SetInteractable (true);
    }
}