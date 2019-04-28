using UnityEngine;

public class EnemiesUI : MonoBehaviour {
    private Character player = null;
    private GameboardControl gameboard;
    EnemiesSlot[] slots;
    void Start () {
        slots = transform.GetComponentsInChildren<EnemiesSlot> ();

    }
    void Update () {
        if (player != null) {
            for (int i = 0; i < slots.Length; i++) {
                if (i < gameboard.GetCMax ()) {
                    slots[i].AddEnemy (gameboard.GetCharacter (i));
                    if (gameboard.GetCharacter (i) == player)
                        slots[i].ClearSlot ();
                } else
                    slots[i].ClearSlot ();
            }
        }
    }
    public void SetPlayer (Character p) {
        player = p;
        gameboard = GameObject.FindWithTag ("GameBoard").GetComponent<GameboardControl> ();
    }
}