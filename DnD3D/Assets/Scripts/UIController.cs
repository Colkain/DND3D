using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    CameraController cam;
    Dropdown m_Dropdown;
    public GameObject gameBoardPrefab;
    [SerializeField] private static int cMax;
    [SerializeField] private Vector3 characterCoor;
    InputField nameField;
    public GameObject creationUI;
    public GameObject inGameUI;
    GameboardControl gameBoard;
    public void Start () {
        creationUI = GameObject.Find ("CreationUI");
        inGameUI = GameObject.Find ("InGameUI");
        SetCreationUI ();
        inGameUI.SetActive (false);
        cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
    }
    public void SettingUp () {
        m_Dropdown = GameObject.FindGameObjectWithTag ("DropDown").GetComponent<Dropdown> ();
        cMax = m_Dropdown.value + 2;
        GameObject gameBoardObject = Instantiate (gameBoardPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        gameBoard = gameBoardObject.GetComponent<GameboardControl> ();
        GameObject.Find ("SettingupUI").SetActive (false);
        gameBoard.StartingGame (cMax);
    }
    public void CreateCharacter (string c) {
        nameField = GameObject.FindGameObjectWithTag ("NameField").GetComponent<InputField> ();
        Spawner s = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<Spawner> ();
        s.SetNewCharacter (gameBoard.GetIdc (), nameField.text, c, characterCoor);
        SetCreationUI ();
        if (gameBoard.GetIdc () == cMax) {
            inGameUI.SetActive (true);
            gameBoard.SetIdc (1);
            string name = "Player" + gameBoard.GetIdc ();
            Character player = GameObject.FindWithTag (name).GetComponent<Character> ();
            player.SetMouvementUI (player.GetMouvement ());
            player.SetisTurn (true);
            gameBoard.SetPreviousTile ();
            cam.SetCamera (gameBoard.GetIdc ());
        } else
            gameBoard.SetIdc (gameBoard.GetIdc () + 1);
    }
    public void SetCreationUI () {
        creationUI.SetActive (false);
    }
    public void SetCreationUI (Vector3 coor) {
        characterCoor = coor;
        creationUI.SetActive (true);
        Text text = GameObject.Find ("PlayerNumber").GetComponent<Text> ();
        text.text = "Player number:" + gameBoard.GetIdc ();
    }
    public void SetCharUI (Character c) {
        Text name = GameObject.Find ("Name").GetComponent<Text> ();
        Text classC = GameObject.Find ("Class").GetComponent<Text> ();
        Text level = GameObject.Find ("Level").GetComponent<Text> ();
        Text health = GameObject.Find ("Health").GetComponent<Text> ();
        Text mouvement = GameObject.Find ("Mouvement").GetComponent<Text> ();
        Text strength = GameObject.Find ("Strength").GetComponent<Text> ();
        Text agility = GameObject.Find ("Agility").GetComponent<Text> ();
        Text intelligence = GameObject.Find ("Intelligence").GetComponent<Text> ();
        Text wisdom = GameObject.Find ("Wisdom").GetComponent<Text> ();
        Text range = GameObject.Find ("Range").GetComponent<Text> ();
        Text power = GameObject.Find ("Power").GetComponent<Text> ();

        name.text = c.GetName ();
        classC.text = c.GetClass ();
        level.text = "Lvl:" + c.GetLevel ().ToString ();
        health.text = "HP:" + c.GetHealth ().ToString () + "/" + c.GetMaxHealth ().ToString ();
        mouvement.text = "Mv:" + c.GetMouvementUI ().ToString ();
        strength.text = "Str:" + c.GetStrength ().ToString ();
        agility.text = "Agi:" + c.GetAgility ().ToString ();
        intelligence.text = "Int:" + c.GetIntelligence ().ToString ();
        wisdom.text = "Wis:" + c.GetWisdom ().ToString ();
        range.text = "Ran:" + c.GetRange ().ToString ();
        power.text = "Power:" + c.GetPower ();
    }
}