using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    CharacterMovement cm;
    [SerializeField] private Character player;
    CameraController cam;
    Dropdown m_Dropdown;
    public GameObject gameBoardPrefab;
    public GameObject statsUI;
    public GameObject itemsUI;
    public GameObject abilitiesUI;
    [SerializeField] private static int cMax;
    [SerializeField] private Vector3 characterCoor;
    InputField nameField;
    private GameObject creationUI;
    private GameObject popupUI;
    GameboardControl gameBoard;
    //Popup UI
    Button popupB;
    TileEvent tileEvent;
    public void Start () {
        creationUI = GameObject.Find ("CreationUI");
        popupUI = GameObject.Find ("InGameUI").transform.GetChild (3).gameObject;
        // popupB = controlsUI.transform.GetChild (3).GetComponent<Button> ();

        SetCreationUI ();
        statsUI.SetActive (false);
        abilitiesUI.SetActive (false);
        itemsUI.SetActive (false);
        popupUI.SetActive (false);
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
            statsUI.SetActive (true);
            abilitiesUI.SetActive (true);
            itemsUI.SetActive (true);
            gameBoard.SetIdc (1);
            string name = "Player" + gameBoard.GetIdc ();
            Character player = GameObject.FindWithTag (name).GetComponent<Character> ();
            player.SetisTurn (true);
            statsUI.GetComponent<StatsUI> ().SetPlayer (player, gameBoard.GetRound());
            abilitiesUI.GetComponent<AbilitiesUI> ().SetPlayer (player, gameBoard.GetRound ());
            itemsUI.GetComponent<InventoryUI> ().SetPlayer (player);
            gameBoard.SetPreviousTile ();
            cam.SetCamera (gameBoard.GetIdc ());
        } else {
            gameBoard.SetIdc (gameBoard.GetIdc () + 1);
            nameField.text = null;
        }
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
    public void LevelUp (int stat) {
        gameBoard.GetCharacters () [gameBoard.GetIdc () - 1].LevelUp (stat);
        statsUI.GetComponent<StatsUI> ().SetLevelUpButtons (false);
    }
    public void SetLevelUpButtons () {
        statsUI.GetComponent<StatsUI> ().SetLevelUpButtons (true);
    }
    public void NextTurnUI (Character c) {
        player = c;
        statsUI.GetComponent<StatsUI> ().SetPlayer (player, gameBoard.GetRound ());
        abilitiesUI.GetComponent<AbilitiesUI> ().SetPlayer (player, gameBoard.GetRound ());
        itemsUI.GetComponent<InventoryUI> ().SetPlayer (player);
    }
    public void AcceptPopup () {
        if (tileEvent.GetId () == 0) {
            gameBoard.AddNewPower (tileEvent.GetPower ());
        } else if (tileEvent.GetId () == 1) {
            gameBoard.AddNewItem (tileEvent.GetItem ());
            popupUI.SetActive (false);
        } else {
            tileEvent.GetHap ().ActivateHap (player);
            popupUI.transform.GetChild (2).GetComponent<Text> ().text = tileEvent.GetHap ().GetDescription ();
            popupUI.transform.GetChild (3).gameObject.SetActive (false);
        }
        tileEvent.ClearEvent ();
    }
    public void ClosePopupUI () {
        popupUI.SetActive (false);
    }
    public void CheckUI (TileEvent te) {
        tileEvent = te;
        popupUI.SetActive (true);
        popupUI.transform.GetChild (1).GetComponent<Text> ().text = te.GetNameE ();
        popupUI.transform.GetChild (2).GetComponent<Text> ().text = te.GetDescription ();
        if (tileEvent.GetId () > 2)
            popupUI.transform.GetChild (3).gameObject.SetActive (false);
        else
            popupUI.transform.GetChild (3).gameObject.SetActive (true);
    }
    public void SetRoundUI (int r) {
        //set round
    }
}