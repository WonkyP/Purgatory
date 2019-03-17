using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panelPlayer1;
    public GameObject panelPlayer2;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }



        // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        panelPlayer1.SetActive(false);
        panelPlayer2.SetActive(false);
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        // Assign references on Scene Load
        if (scene.name == "Arena")
        {
            //panelPlayer1.SetActive(false);
            //panelPlayer2.SetActive(false);
        }

    }

    public void TakeDamage(float currentLife, int player_Id)
    {
        if(currentLife <= 0)
        {

             GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MenuBehaviour>().GoToInventory();
             SceneManager.LoadScene(1);

            //Debug.Log("Current life is 0 or less!");
            //panelPlayer1.SetActive(true);
            //Debug.Log("Player1 panel activated");
            //panelPlayer2.SetActive(true);
        }
    }
}
