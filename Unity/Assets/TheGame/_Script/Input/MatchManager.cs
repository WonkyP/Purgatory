using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
    
    ////Cameras for each player
    //public Camera cam1;
    //public Camera cam2;
    //public Camera cam3;
    //public Camera cam4;

    //Original positions of the players
    public GameObject player1;
    public GameObject player2;
    //public GameObject spawn3;
    //public GameObject spawn4;

    //Object with the controller of the player, for example, cars, characters or whatever
    public GameObject[] characters;

    //Number of players
    int Nplayer;

    private void Awake()
    {
        // = GameObject.Find("InputManager").GetComponent<InputManager>();
        Nplayer = PlayerPrefs.GetInt("Nplayers");

        //Switch encargado de generar los aviones, que podrian solo asignarse segun el numero de jugadores
        //Tambien debe encargarse de ajustar el HUD a las posiciones correctas

        //switch (Nplayer)
        //{
        //    case 2:
        //        {
        //In each case we destroy the elements we wont need
        //Destroy(cam3.gameObject);
        //Destroy(cam4.gameObject);
        //Destroy(spawn3);
        //Destroy(spawn4);


        ////Set the cameras size/position for the correct number of players
        //cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
        //cam2.rect = new Rect(0, 0, 1, 0.5f);

        //Instantiate the correct object
        //GameObject player1 = Instantiate(characters[/*The one that player chose in the menu*/ 0], this.player1.transform.position, this.player1.transform.rotation);

                    //Set the number of the controller of each player
                    player1.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player1Controller"));

                    //Set the number of the camera that is going to follow our character
                    //player1.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player1Position"));

                    //Check and set if this player is controlled by a DS4 controller
                    if (PlayerPrefs.GetInt("Player1PS4") == 1)
                        player1.GetComponent<Player>().setPS4();


        //GameObject player2 = Instantiate(characters[/*The one that player chose in the menu*/ 0], this.player2.transform.position, this.player2.transform.rotation);
                    player2.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player2Controller"));
                    //player2.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player2Position"));
                    if (PlayerPrefs.GetInt("Player2PS4") == 1)
                        player2.GetComponent<Player>().setPS4();

        //            break;
        //        }
        //    case 3:
        //        {
        //            Destroy(cam4.gameObject);
        //            Destroy(spawn4);

        //            cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        //            cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        //            cam3.rect = new Rect(0, 0, 1, 0.5f);

        //            GameObject p1 = Instantiate(characters[/*The one that player chose in the menu*/ 0], player1.transform.position, player1.transform.rotation);
        //            p1.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player1Controller"));
        //            p1.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player1Position"));
        //            if (PlayerPrefs.GetInt("Player1PS4") == 1)
        //                p1.GetComponent<Player>().setPS4();

        //            GameObject p2 = Instantiate(characters[/*The one that player chose in the menu*/ 0], player2.transform.position, player2.transform.rotation);
        //            p2.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player2Controller"));
        //            p2.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player2Position"));
        //            if (PlayerPrefs.GetInt("Player2PS4") == 1)
        //                p2.GetComponent<Player>().setPS4();

        //            GameObject p3 = Instantiate(characters[/*The one that player chose in the menu*/ 0], spawn3.transform.position, spawn3.transform.rotation);
        //            p3.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player3Controller"));
        //            p3.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player3Position"));
        //            if (PlayerPrefs.GetInt("Player3PS4") == 1)
        //                p3.GetComponent<Player>().setPS4();

        //            break;
        //        }
        //    case 4:
        //        {
        //            cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        //            cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        //            cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
        //            cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);

        //            GameObject p1 = Instantiate(characters[/*The one that player chose in the menu*/ 0], player1.transform.position, player1.transform.rotation);
        //            p1.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player1Controller"));
        //            p1.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player1Position"));
        //            if (PlayerPrefs.GetInt("Player1PS4") == 1)
        //                p1.GetComponent<Player>().setPS4();

        //            GameObject p2 = Instantiate(characters[/*The one that player chose in the menu*/ 0], player2.transform.position, player2.transform.rotation);
        //            p2.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player2Controller"));
        //            p2.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player2Position"));
        //            if (PlayerPrefs.GetInt("Player2PS4") == 1)
        //                p2.GetComponent<Player>().setPS4();


        //            GameObject p3 = Instantiate(characters[/*The one that player chose in the menu*/ 0], spawn3.transform.position, spawn3.transform.rotation);
        //            p3.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player3Controller"));
        //            p3.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player3Position"));
        //            if (PlayerPrefs.GetInt("Player3PS4") == 1)
        //                p3.GetComponent<Player>().setPS4();

        //            GameObject p4 = Instantiate(characters[/*The one that player chose in the menu*/ 0], spawn4.transform.position, spawn4.transform.rotation);
        //            p4.GetComponent<Player>().setNumber(PlayerPrefs.GetInt("Player4Controller"));
        //            p4.GetComponent<Player>().setCamNumber(PlayerPrefs.GetInt("Player4Position"));
        //            if (PlayerPrefs.GetInt("Player4PS4") == 1)
        //                p4.GetComponent<Player>().setPS4();

        //            break;
        //        }
        //}
    }

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
