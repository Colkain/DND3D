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
    //inGame Texts
    GameObject nameC;
    GameObject classC;
    GameObject level;
    GameObject health;
    GameObject mouvement;
    GameObject strength;
    GameObject agility;
    GameObject intelligence;
    GameObject wisdom;
    GameObject range;
    GameObject power;
    //inGame Buttons
    Button mouvementB;
    Button healthB;
    Button strengthB;
    Button agilityB;
    Button intelligenceB;
    Button wisdomB;
    bool startOfTheGame;
    public void Start () {
        creationUI = GameObject.Find ("CreationUI");
        inGameUI = GameObject.Find ("InGameUI");
        SetCreationUI ();
        inGameUI.SetActive (false);
        cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
        startOfTheGame = true;
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
        nameC = GameObject.Find ("Name");
        classC = GameObject.Find ("Class");
        level = GameObject.Find ("Level");
        health = GameObject.Find ("Health");
        mouvement = GameObject.Find ("Mouvement");
        strength = GameObject.Find ("Strength");
        agility = GameObject.Find ("Agility");
        intelligence = GameObject.Find ("Intelligence");
        wisdom = GameObject.Find ("Wisdom");
        range = GameObject.Find ("Range");
        power = GameObject.Find ("Power");

        if (startOfTheGame) {
            SetLevelUpButtons (false);
            startOfTheGame = false;
        }

        nameC.GetComponent<Text> ().text = c.GetName ();
        classC.GetComponent<Text> ().text = c.GetClass ();
        level.GetComponent<Text> ().text = "Lvl:" + c.GetLevel ().ToString ();
        health.GetComponent<Text> ().text = "HP:" + c.GetHealth ().ToString () + "/" + c.GetMaxHealth ().ToString ();
        mouvement.GetComponent<Text> ().text = "Mv:" + c.GetMouvementUI ().ToString ();
        strength.GetComponent<Text> ().text = "Str:" + c.GetStrength ().ToString ();
        agility.GetComponent<Text> ().text = "Agi:" + c.GetAgility ().ToString ();
        intelligence.GetComponent<Text> ().text = "Int:" + c.GetIntelligence ().ToString ();
        wisdom.GetComponent<Text> ().text = "Wis:" + c.GetWisdom ().ToString ();
        range.GetComponent<Text> ().text = "Ran:" + c.GetRange ().ToString ();
        power.GetComponent<Text> ().text = "Powers:\n* " + c.GetPower ();
    }

    public void SetLevelUpButtons (bool a) {
        mouvement.transform.GetChild (0).gameObject.SetActive (a);
        health.transform.GetChild (0).gameObject.SetActive (a);
        strength.transform.GetChild (0).gameObject.SetActive (a);
        agility.transform.GetChild (0).gameObject.SetActive (a);
        intelligence.transform.GetChild (0).gameObject.SetActive (a);
        wisdom.transform.GetChild (0).gameObject.SetActive (a);
    }

}