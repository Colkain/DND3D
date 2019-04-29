using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour {
    private Power power;
    public Image icon;
    public Button powerButton;
    public Button removeButton;
    public Text cooldownText;
    public GameObject hoverPanel;
    void Start () {
        cooldownText.enabled = false;
    }
    void Update () {
        if (power != null) {
            cooldownText.text = power.GetCooldownUI ().ToString ();
            if (power.GetCooldownUI () > 0) {
                cooldownText.enabled = true;
                powerButton.image.color = Color.red;
            } else {
                cooldownText.enabled = false;
                powerButton.image.color = Color.white;
            }
        }
    }
    public void AddPower (Power newPower) {
        power = newPower;
        icon.sprite = power.GetIcon ();
        icon.enabled = true;
        powerButton.interactable = true;
        removeButton.interactable = true;
    }
    public void ClearSlot () {
        power = null;

        powerButton.image.color = Color.white;
        icon.sprite = null;
        icon.enabled = false;
        powerButton.interactable = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton () {
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().RemovePower (power);
    }
    public void OnPowerButton () {
        GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ().GetPlayer ().ActivateEffect (power);
    }
    public void OnMouseOver () {
        if (power != null) {
            hoverPanel.GetComponent<HoverUI> ().SetPosition (gameObject.transform.position, new Vector3 (10, 8, 0), power.GetName (), power.GetDescription ());
            hoverPanel.SetActive (true);
        }
    }
    public void OnMouseExit () {
        hoverPanel.GetComponent<HoverUI> ().SetPositioned (false);
        hoverPanel.SetActive (false);
    }
}