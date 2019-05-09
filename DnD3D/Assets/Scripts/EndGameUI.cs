using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {
    public Text winner;
    PlayerEndGame[] slots;
    void Start () {
        slots = transform.GetComponentsInChildren<PlayerEndGame> ();
    }
    public void SetUI (GameboardControl gameboard) {
        winner.text = "Player " + gameboard.GetAliveCharacter ().GetId () + " is the winner";
        slots[0].AddPlayer (gameboard.GetAliveCharacter ());
        for (int i = 1; i < slots.Length; i++) {
            if (i < gameboard.GetCMax ())
                slots[i].AddPlayer (gameboard.GetDedCharacter (i));
            else
                slots[i].ClearSlot ();
        }
    }
    public void OnMainMenu () {
        SceneManager.LoadScene (0, LoadSceneMode.Single);
    }
}