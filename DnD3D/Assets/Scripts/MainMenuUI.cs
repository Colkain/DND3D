﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject settingUp;
    private int cMax = 0;
    private int columns = 0;
    private int rows = 0;
    void Start () {
        settingUp.SetActive (false);
    }
    public void OnLocalMachine () {
        mainMenu.SetActive (false);
        settingUp.SetActive (true);
    }
    public void OnHost () { }
    public void OnJoin () { }
    public void OnQuit () {
        Application.Quit ();
    }
    public void OnSubmit () {
        cMax = settingUp.transform.GetChild (1).GetChild (0).GetChild (1).GetComponent<Dropdown> ().value + 2;
        columns = int.Parse (settingUp.transform.GetChild (1).GetChild (1).GetChild (1).GetComponent<InputField> ().text);
        rows = int.Parse (settingUp.transform.GetChild (1).GetChild (2).GetChild (1).GetComponent<InputField> ().text);
        if (cMax > 0 && rows > 0 && columns > 0) {
            Parameters.cMax = cMax;
            Parameters.columns = columns;
            Parameters.rows = rows;
            SceneManager.LoadScene (1, LoadSceneMode.Single);
        }
    }
    public void OnReturn () {
        mainMenu.SetActive (true);
        settingUp.SetActive (false);
    }
}