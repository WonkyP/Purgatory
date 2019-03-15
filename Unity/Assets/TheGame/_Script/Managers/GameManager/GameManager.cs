using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        panelPlayer1.SetActive(false);
        panelPlayer2.SetActive(false);
    }



        // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        panelPlayer1.SetActive(false);
        panelPlayer2.SetActive(false);
    }

    private void OnLevelWasLoaded(int level)
    {
        panelPlayer1.SetActive(false);
        panelPlayer2.SetActive(false);
    }

    public void takeDamage(float currentLife, int player_Id)
    {
        if(currentLife <= 0)
        {
            panelPlayer1.SetActive(true);
            panelPlayer2.SetActive(true);
        }
    }
}
