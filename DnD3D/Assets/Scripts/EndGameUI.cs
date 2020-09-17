using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {
    public void SetUI (GameboardControl gameboard) {
        transform.GetChild (1).GetComponent<TMPro.TMP_Text> ().text = gameboard.GetAliveCharacter ().GetName () + " is the winner!";
    }
}