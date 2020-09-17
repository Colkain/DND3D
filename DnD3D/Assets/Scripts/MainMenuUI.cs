using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    public GameObject mainMenu;

    public GameObject HowTo;

    public GameObject settingUp;

    private int cMax = 0;

    private int columns = 0;

    private int rows = 0;

    void Start () {
        settingUp.SetActive (false);
        HowTo.SetActive (false);
    }

    public void OnPlay () {
        mainMenu.SetActive (false);
        settingUp.SetActive (true);
    }

    public void OnHowTo () {
        mainMenu.SetActive (false);
        HowTo.SetActive (true);
    }

    public void OnQuit () {
        Application.Quit ();
    }

    public void OnSubmit () {
        cMax = settingUp
            .transform
            .GetChild (1)
            .GetComponent<TMPro.TMP_Dropdown> ()
            .value + 2;
        rows =
            int
            .Parse (settingUp
                .transform
                .GetChild (3)
                .GetComponent<TMPro.TMP_InputField> ()
                .text);
        columns =
            int
            .Parse (settingUp
                .transform
                .GetChild (5)
                .GetComponent<TMPro.TMP_InputField> ()
                .text);
        Parameters.cMax = cMax;
        Parameters.columns = columns;
        Parameters.rows = rows;
        SceneManager.LoadScene (1, LoadSceneMode.Single);
    }

    public void OnReturn () {
        mainMenu.SetActive (true);
        settingUp.SetActive (false);
        HowTo.SetActive (false);
    }
}