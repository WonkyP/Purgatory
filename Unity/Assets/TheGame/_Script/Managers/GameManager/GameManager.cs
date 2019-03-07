using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panelPlayer1;
    public GameObject panelPlayer2;

    public Text player1Text;
    public Text player2Text;

    void Start()
    {
        instance = this;
    }



        // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int currentLife, int player_Id)
    {
        if(currentLife <= 0)
        {
            panelPlayer1.SetActive(true);
            panelPlayer2.SetActive(true);

            if(player_Id == 1)
            {
                player1Text.text = "You DIED"; 
                player2Text.text = "You WON";
            }
            else
            {

                 player1Text.text = "You WON";
                 player2Text.text = "You DIED";
            }
        }
    }
}
