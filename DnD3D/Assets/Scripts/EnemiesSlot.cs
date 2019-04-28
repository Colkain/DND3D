using UnityEngine;
using UnityEngine.UI;

public class EnemiesSlot : MonoBehaviour {
    private Character enemy;
    public Text nameE;
    public Text healthText;
    public Transform healthBar;
    private float health;
    void Update () {
        if (enemy != null) { }
    }
    public void AddEnemy (Character newEnemy) {
        gameObject.SetActive (true);
        enemy = newEnemy;
        nameE.text = enemy.GetName ();
        healthText.text = enemy.GetHealth () + "/" + enemy.GetMaxHealth ();
        health = (float)enemy.GetHealth () / enemy.GetMaxHealth ();
        healthBar.localScale = new Vector3 (health, 1, 1);
    }
    public void ClearSlot () {
        gameObject.SetActive (false);
    }
}