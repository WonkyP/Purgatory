using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuBehaviour : MonoBehaviour
{
    public static MenuBehaviour instance;

    public GameObject AudioManagerObject;
    private GameObject PauseMenu;

    public Button ArenaButton;

    //[SerializeField]
    //private PlayerManager playerManager;

    [SerializeField]
    private PlayerSystem player1System;

    [SerializeField]
    private PlayerSystem player2System;

    [SerializeField]
    private SplitScreen splitScreen;

    //------------------------------------------------------
    // TESTING: CAN BE DELETED
    Weapon_Attack atk1_2 = new Weapon_Attack("Attack 1_Combo2", 1, "Attack");
    Weapon_Attack atk2_2 = new Weapon_Attack("Attack 2_Combo2", 2, "Attack");
    Weapon_Attack atk3_2 = new Weapon_Attack("Attack 3_Combo3", 3, "Attack");
    //------------------------------------------------------


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        // Assign references on Scene Load
        if(scene.name == "Inventory01")
        {
            ArenaButton = GameObject.Find("Canvas_Player01_Inventory_Cards").transform.GetChild(1).GetComponent<Button>();
            ArenaButton.onClick.AddListener(GoToArena);


            player1System = GameObject.FindGameObjectWithTag("Player1System").GetComponent<PlayerSystem>();
            player2System = GameObject.FindGameObjectWithTag("Player2System").GetComponent<PlayerSystem>();

            splitScreen = GameObject.FindGameObjectWithTag("SplitScreenSystem").GetComponent<SplitScreen>();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //if (GameObject.FindGameObjectWithTag("Menu_Pause").gameObject != null)
        //{
        //    PauseMenu = GameObject.FindGameObjectWithTag("Menu_Pause").gameObject;
        //    PauseMenu.SetActive(false);
        //}
        //else return;

    }
    
    //Button functions
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToInventory()
    {
        SceneManager.LoadScene(1);

        player1System.PlayerCamera.SetActive(false);
        player1System.Player.SetActive(false);

        player2System.PlayerCamera.SetActive(false);
        player2System.Player.SetActive(false);

        splitScreen.MainHealthCanvas.SetActive(false);

       
    }

    public void GoToArena()
    {
        player1System.PlayerManager.ComboSystem.createComboQueue(player1System.PlayerManager.CurrentComboSet1, player1System.PlayerManager.ComboSet1);
        //PlayerDataHandler.instance.saveComboSet1(1, player1System.PlayerManager.ComboSet1);
        //playerManager.ComboSystem.createComboQueue(playerManager.CurrentComboSet2, playerManager.ComboSet2);

        // TESTING
        player1System.PlayerManager.ComboSystem.addAttackToCombo(player1System.PlayerManager.CurrentComboSet2, atk1_2);
        player1System.PlayerManager.ComboSystem.addAttackToCombo(player1System.PlayerManager.CurrentComboSet2, atk2_2);
        player1System.PlayerManager.ComboSystem.addAttackToCombo(player1System.PlayerManager.CurrentComboSet2, atk3_2);
        player1System.PlayerManager.ComboSystem.createComboQueue(player1System.PlayerManager.CurrentComboSet2, player1System.PlayerManager.ComboSet2);
        // TESTING

        SceneManager.LoadScene(2);

        // We activate the camera and the player
        player1System.PlayerCamera.SetActive(true);
        player1System.Player.SetActive(true);

        player2System.PlayerCamera.SetActive(true);
        player2System.Player.SetActive(true);

        splitScreen.MainHealthCanvas.SetActive(true);

        AudioManagerObject.GetComponent<AudioManager>().ArenaStart();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySFX()
    {
        AudioManagerObject.GetComponent<AudioManager>().MenuClickSFX();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
        }
    }
}
