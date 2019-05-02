using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] private Character player;
    CameraController cam;
    Dropdown m_Dropdown;
    public GameObject gameBoardPrefab;
    public GameObject hoverPanel;
    public GameObject statsUI;
    public GameObject itemsUI;
    public GameObject popupUI;
    public GameObject abilitiesUI;
    public GameObject buffsUI;
    public GameObject playersUI;
    public GameObject characterCreationUI;
    public GameObject endGameUI;
    [SerializeField] private static int cMax;
    [SerializeField] private Vector3 characterCoor;
    InputField nameField;
    GameboardControl gameBoard;
    TileEvent tileEvent;
    public void Start () {
        characterCreationUI.SetActive (false);
        endGameUI.SetActive (false);
        hoverPanel.SetActive (false);
        buffsUI.SetActive (false);
        playersUI.SetActive (false);
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
        if (nameField.text != "") {
            Spawner s = GameObject.FindGameObjectWithTag ("GameBoard").GetComponent<Spawner> ();
            s.SetNewCharacter (gameBoard.GetIdc (), nameField.text, c, characterCoor);
            characterCreationUI.SetActive (false);
            if (gameBoard.GetIdc () == cMax) {
                statsUI.SetActive (true);
                playersUI.SetActive (true);
                abilitiesUI.SetActive (true);
                buffsUI.SetActive (true);
                itemsUI.SetActive (true);
                gameBoard.SetIdc (1);
                string name = "Player" + gameBoard.GetIdc ();
                player = GameObject.FindWithTag (name).GetComponent<Character> ();
                player.SetisTurn (true);
                statsUI.GetComponent<StatsUI> ().SetPlayer (player, gameBoard.GetRound ());
                playersUI.GetComponent<PlayersUI> ().SetUI (gameBoard.GetComponent<GameboardControl> ());
                abilitiesUI.GetComponent<AbilitiesUI> ().SetPlayer (player, gameBoard.GetRound ());
                itemsUI.GetComponent<InventoryUI> ().SetPlayer (player);
                buffsUI.GetComponent<BuffsUI> ().SetPlayer (player);
                gameBoard.SetPreviousTile ();
                cam.SetCamera (gameBoard.GetIdc ());
            } else {
                gameBoard.SetIdc (gameBoard.GetIdc () + 1);
                nameField.text = null;
            }
        }
    }
    public void SetPlayer (Character p) {
        player = p;
    }
    public void SetCreationUI (Vector3 coor) {
        characterCoor = coor;
        characterCreationUI.SetActive (true);
        Text text = GameObject.Find ("PlayerNumber").GetComponentInChildren<Text> ();
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
        buffsUI.GetComponent<BuffsUI> ().SetPlayer (player);
    }
    public void AcceptPopup () {
        if (tileEvent.GetId () == 0) {
            gameBoard.AddNewPower (tileEvent.GetPower ());
            popupUI.SetActive (false);
        } else if (tileEvent.GetId () == 1) {
            gameBoard.AddNewItem (tileEvent.GetItem ());
            popupUI.SetActive (false);
        } else {
            tileEvent.GetHap ().ActivateHap (player);
            popupUI.transform.GetChild (1).transform.GetChild (0).GetComponent<Text> ().text = tileEvent.GetHap ().GetDescription ();
            popupUI.transform.GetChild (2).gameObject.SetActive (false);
        }
        tileEvent.ClearEvent ();
    }
    public void SetDeadCharacters () {

    }
    public void ClosePopupUI () {
        popupUI.SetActive (false);
    }
    public void CheckUI (TileEvent te) {
        tileEvent = te;
        popupUI.SetActive (true);
        popupUI.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = te.GetNameE ();
        popupUI.transform.GetChild (1).transform.GetChild (0).GetComponent<Text> ().text = te.GetDescription ();
        if (tileEvent.GetId () > 2)
            popupUI.transform.GetChild (2).gameObject.SetActive (false);
        else
            popupUI.transform.GetChild (2).gameObject.SetActive (true);
    }
}