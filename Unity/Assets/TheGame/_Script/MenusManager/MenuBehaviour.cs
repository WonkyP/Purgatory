using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuBehaviour : MonoBehaviour
{
    public GameObject AudioManagerObject;
    private GameObject PauseMenu;

    //[SerializeField]
    //private PlayerManager playerManager;

    [SerializeField]
    private PlayerSystem player1System;

    [SerializeField]
    private PlayerSystem player2System;

    [SerializeField]
    private SplitScreen splitScreen;



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

    public void NextScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToArena()
    {
        player1System.PlayerManager.ComboSystem.createComboQueue(player1System.PlayerManager.CurrentComboSet1, player1System.PlayerManager.ComboSet1);
        //PlayerDataHandler.instance.saveComboSet1(1, player1System.PlayerManager.ComboSet1);
        //playerManager.ComboSystem.createComboQueue(playerManager.CurrentComboSet2, playerManager.ComboSet2);
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
