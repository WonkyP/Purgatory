using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManagerAsset : MonoBehaviour {
    //Player 1 data

    public Text player1Text;
    public Text player2Text;

    public string sceneName = "";
    bool player1Joined = false;     //When player1 is joined
    int player1contr = -1;          //The number of the controller assigned to player1
    bool player1Start = false;      //When player1 is locked

    //Variables to make the Dpad axis work as buttons
    bool selection1H = false;
    bool selection1V = false;

    //Player 2 data
    bool player2Joined = false;
    int player2contr = -1;
    bool player2Start = false;
    bool selection2H = false;
    bool selection2V = false;

    //Player 3 data
    bool player3Joined = false;
    int player3contr = -1;
    bool player3Start = false;
    bool selection3H = false;
    bool selection3V = false;

    //Player 4 data
    bool player4Joined = false;
    int player4contr = -1;
    bool player4Start = false;
    bool selection4H = false;
    bool selection4V = false;

    int checks = 0;             //The number of players that have locked their selection
    int controllerCount = 1;    //Variable to control the number of player joined
    int controllers = 0;        //Number of controllers conected in every tick


    private void Start()
    {
        player1Text.text = "Waiting for player 1";
        player2Text.text = "Waiting for player 2";
    }



    // Update is called once per frame
    void Update()
    {
        controllers = Input.GetJoystickNames().Length;
        //We go through all the conected controller in order
        for (int i = 1; i <= controllers; i++)
        {
            if (Input.GetJoystickNames()[i - 1] == "Wireless Controller")       //DS4 controllers always have this name, V1 or V2, doesn't matter
            {
                if (hInput.GetButtonDown("APS" + i))        //The cross button of the DS4 controller
                {
                    if (!player1Joined)
                    {
                        //Save the number of the controller for the player1
                        player1contr = i;
                        PlayerPrefs.SetInt("Player1Controller", player1contr);

                        //We set a 1 if is a DS4 controller or 0 if is not (Here we set it always with 1)
                        PlayerPrefs.SetInt("Player1PS4", 1);

                        //This way we will be able to make this player to be the player1
                        PlayerPrefs.SetInt("Player1Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player1 joined");
                        player1Text.text = "Player1 joined";

                        player1Joined = true;

                        break;
                    }
                    else if (!player2Joined && i != player1contr)
                    {
                        player2contr = i;
                        PlayerPrefs.SetInt("Player2Controller", i);

                        PlayerPrefs.SetInt("Player2PS4", 1);

                        PlayerPrefs.SetInt("Player2Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player2 joined");
                        player2Text.text = "Player2 joined";

                        player2Joined = true;

                        break;
                    }
                    else if (!player3Joined && i != player1contr && i != player2contr)
                    {
                        player3contr = i;
                        PlayerPrefs.SetInt("Player3Controller", i);

                        PlayerPrefs.SetInt("Player3PS4", 1);

                        PlayerPrefs.SetInt("Player3Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player3 joined");
                        player3Joined = true;

                        break;
                    }
                    else if (!player4Joined && i != player1contr && i != player2contr && i != player3contr)
                    {
                        player4contr = i;
                        PlayerPrefs.SetInt("Player4Controller", i);

                        PlayerPrefs.SetInt("Player4PS4", 1);

                        PlayerPrefs.SetInt("Player4Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player4 joined");
                        player4Joined = true;

                        break;
                    }
                }


                if (hInput.GetButtonDown("BPS" + i))    //The circle button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {
                        Debug.LogWarning("Player1 unlocked");
                        checks--;
                        player1Start = false;
                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {
                        Debug.LogWarning("Player2 unlocked");
                        checks--;
                        player2Start = false;
                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {
                        Debug.LogWarning("Player3 unlocked");
                        checks--;
                        player3Start = false;
                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {
                        Debug.LogWarning("Player4 unlocked");
                        checks--;
                        player4Start = false;
                        break;
                    }
                }


                if (hInput.GetButtonDown("XPS" + i))        //The square button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("Y" + i))      //The triangle button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("LeftBumper" + i))     //The L1 button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("RightBumper" + i))        //The R1 button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("L3PS" + i))       //The L3 button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("R3PS" + i))       //The R3 button of the DS4 controller
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                //HORIZONTAL DPAD CHANGE
                if (Mathf.Abs(Input.GetAxis("DpadHorizontalPS" + i)) > 0)
                {
                    if (!selection1H && i == player1contr && !player1Start)
                    {
                        if (Input.GetAxis("DpadHorizontalPS" + i) > 0)  //Right button of the DPAD
                        {

                        }
                        else         //Left button of the DPAD
                        {

                        }
                        //Lock the DPAD to act as a normal button
                        selection1H = true;
                        break;
                    }
                    else if (!selection2H && i == player2contr && !player2Start)
                    {
                        if (Input.GetAxis("DpadHorizontalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection2H = true;
                        break;
                    }
                    else if (!selection3H && i == player3contr && !player3Start)
                    {
                        if (Input.GetAxis("DpadHorizontalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection3H = true;
                        break;
                    }
                    else if (!selection4H && i == player4contr && !player4Start)
                    {
                        if (Input.GetAxis("DpadHorizontalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection4H = true;
                        break;
                    }
                }
                else
                {
                    if (selection1H && i == player1contr && !player1Start)
                    {
                        //Unlock the Horizontal DPAD
                        selection1H = false;
                        break;
                    }
                    else if (selection2H && i == player2contr && !player2Start)
                    {
                        selection2H = false;
                        break;
                    }
                    else if (selection3H && i == player3contr && !player3Start)
                    {
                        selection3H = false;
                        break;
                    }
                    else if (selection4H && i == player4contr && !player4Start)
                    {
                        selection4H = false;
                        break;
                    }
                }


                //Vertical DPAD CHANGE
                if (Mathf.Abs(Input.GetAxis("DpadVerticalPS" + i)) > 0)
                {
                    if (!selection1V && i == player1contr && !player1Start)
                    {
                        if (Input.GetAxis("DpadVerticalPS" + i) > 0)  //Up button of the DPAD
                        {

                        }
                        else        //Down button of the DPAD
                        {

                        }
                        selection1V = true;
                        break;
                    }
                    else if (!selection2V && i == player2contr && !player2Start)
                    {
                        if (Input.GetAxis("DpadVerticalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection2V = true;
                        break;
                    }
                    else if (!selection3V && i == player3contr && !player3Start)
                    {
                        if (Input.GetAxis("DpadVerticalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection3V = true;
                        break;
                    }
                    else if (!selection4V && i == player4contr && !player4Start)
                    {
                        if (Input.GetAxis("DpadVerticalPS" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection4V = true;
                        break;
                    }
                }
                else
                {
                    if (selection1V && i == player1contr && !player1Start)
                    {
                        selection1V = false;
                        break;
                    }
                    else if (selection2V && i == player2contr && !player2Start)
                    {
                        selection2V = false;
                        break;
                    }
                    else if (selection3V && i == player3contr && !player3Start)
                    {
                        selection3V = false;
                        break;
                    }
                    else if (selection4V && i == player4contr && !player4Start)
                    {
                        selection4V = false;
                        break;
                    }
                }


                if (hInput.GetButtonDown("SelectPS" + i))            //The Share button of the DS4 controller
                {
                    if (i == player1contr && !player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && !player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && !player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && !player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("StartPS" + i))            //The Options button of the DS4 controller
                {
                    if (i == player1contr && !player1Start)
                    {
                        player1Start = true;
                        Debug.LogWarning("Player1 locked");
                        player1Text.text = "Player1 locked, ready to go";
                        checks++;
                        break;
                    }
                    else if (i == player2contr && !player2Start)
                    {
                        player2Start = true;
                        Debug.LogWarning("Player2 locked");
                        player2Text.text = "Player2 locked, ready to go";

                        checks++;
                        break;
                    }
                    else if (i == player3contr && !player3Start)
                    {
                        player3Start = true;
                        Debug.LogWarning("Player3 locked");
                        checks++;
                        break;
                    }
                    else if (i == player4contr && !player4Start)
                    {
                        player4Start = true;
                        Debug.LogWarning("Player4 locked");
                        checks++;
                        break;
                    }
                }
            }



            // XINPUT BASED CONTROLLERS (Like xbox360, xboxOne, DS3... and others)

            else
            {
                if (hInput.GetButtonDown("A" + i))
                {
                    if (!player1Joined)
                    {
                        player1contr = i;
                        PlayerPrefs.SetInt("Player1Controller", i);

                        PlayerPrefs.SetInt("Player1PS4", 0);

                        PlayerPrefs.SetInt("Player1Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player1 joined");
                        player1Text.text = "Player1 joined";

                        player1Joined = true;

                        break;
                    }
                    else if (!player2Joined)
                    {
                        player2contr = i;
                        PlayerPrefs.SetInt("Player2Controller", i);

                        PlayerPrefs.SetInt("Player2PS4", 0);

                        PlayerPrefs.SetInt("Player2Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player2 joined");
                        player2Text.text = "Player2 joined";
                        player2Joined = true;

                        break;
                    }
                    else if (!player3Joined)
                    {
                        player3contr = i;
                        PlayerPrefs.SetInt("Player3Controller", i);

                        PlayerPrefs.SetInt("Player3PS4", 0);

                        PlayerPrefs.SetInt("Player3Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player3 joined");
                        player3Joined = true;

                        break;
                    }
                    else if (!player4Joined)
                    {
                        player4contr = i;
                        PlayerPrefs.SetInt("Player4Controller", i);

                        PlayerPrefs.SetInt("Player4PS4", 0);

                        PlayerPrefs.SetInt("Player4Position", controllerCount);
                        controllerCount++;

                        Debug.LogWarning("Player4 joined");
                        player4Joined = true;

                        break;
                    }
                }


                if (hInput.GetButtonDown("B" + i))
                {
                    if (i == player1contr && player1Start)
                    {
                        Debug.LogWarning("Player1 unlocked");
                        checks--;
                        player1Start = false;
                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {
                        Debug.LogWarning("Player2 unlocked");
                        checks--;
                        player2Start = false;
                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {
                        Debug.LogWarning("Player3 unlocked");
                        checks--;
                        player3Start = false;
                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {
                        Debug.LogWarning("Player4 unlocked");
                        checks--;
                        player4Start = false;
                        break;
                    }
                }


                if (hInput.GetButtonDown("X" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("Y" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("LeftBumper" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("RightBumper" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("L3" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("R3" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (Mathf.Abs(Input.GetAxis("DpadHorizontal" + i)) > 0)
                {
                    if (!selection1H && i == player1contr && !player1Start)
                    {
                        if (Input.GetAxis("DpadHorizontal" + i) > 0)  //Si es hacia la derecha
                        {

                        }
                        else
                        {

                        }
                        selection1H = true;
                        break;
                    }
                    else if (!selection2H && i == player2contr && !player2Start)
                    {
                        if (Input.GetAxis("DpadHorizontal" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection2H = true;
                        break;
                    }
                    else if (!selection3H && i == player3contr && !player3Start)
                    {
                        if (Input.GetAxis("DpadHorizontal" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection3H = true;
                        break;
                    }
                    else if (!selection4H && i == player4contr && !player4Start)
                    {
                        if (Input.GetAxis("DpadHorizontal" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection4H = true;
                        break;
                    }
                }
                else
                {
                    if (selection1H && i == player1contr && !player1Start)
                    {
                        selection1H = false;
                        break;
                    }
                    else if (selection2H && i == player2contr && !player2Start)
                    {
                        selection2H = false;
                        break;
                    }
                    else if (selection3H && i == player3contr && !player3Start)
                    {
                        selection3H = false;
                        break;
                    }
                    else if (selection4H && i == player4contr && !player4Start)
                    {
                        selection4H = false;
                        break;
                    }
                }


                if (Mathf.Abs(Input.GetAxis("DpadVertical" + i)) > 0)
                {
                    if (!selection1V && i == player1contr && !player1Start)
                    {
                        if (Input.GetAxis("DpadVertical" + i) > 0)  //Si es hacia la derecha
                        {

                        }
                        else
                        {

                        }
                        selection1V = true;
                        break;
                    }
                    else if (!selection2V && i == player2contr && !player2Start)
                    {
                        if (Input.GetAxis("DpadVertical" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection2V = true;
                        break;
                    }
                    else if (!selection3V && i == player3contr && !player3Start)
                    {
                        if (Input.GetAxis("DpadVertical" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection3V = true;
                        break;
                    }
                    else if (!selection4V && i == player4contr && !player4Start)
                    {
                        if (Input.GetAxis("DpadVertical" + i) > 0)
                        {

                        }
                        else
                        {

                        }
                        selection4V = true;
                        break;
                    }
                }
                else
                {
                    if (selection1V && i == player1contr && !player1Start)
                    {
                        selection1V = false;
                        break;
                    }
                    else if (selection2V && i == player2contr && !player2Start)
                    {
                        selection2V = false;
                        break;
                    }
                    else if (selection3V && i == player3contr && !player3Start)
                    {
                        selection3V = false;
                        break;
                    }
                    else if (selection4V && i == player4contr && !player4Start)
                    {
                        selection4V = false;
                        break;
                    }
                }


                if (hInput.GetButtonDown("Select" + i))
                {
                    if (i == player1contr && player1Start)
                    {

                        break;
                    }
                    else if (i == player2contr && player2Start)
                    {

                        break;
                    }
                    else if (i == player3contr && player3Start)
                    {

                        break;
                    }
                    else if (i == player4contr && player4Start)
                    {

                        break;
                    }
                }


                if (hInput.GetButtonDown("Start" + i))                  //Da igual que mando pulses primero
                {
                    if (i == player1contr)
                    {
                        player1Start = true;
                        Debug.LogWarning("Player1 locked");
                        player1Text.text = "Player 1 ready to go";
                        checks++;
                        break;
                    }
                    else if (i == player2contr)
                    {
                        player2Start = true;
                        Debug.LogWarning("Player2 locked");
                        player2Text.text = "Player 2 ready to go";
                        checks++;
                        break;
                    }
                    else if (i == player3contr)
                    {
                        player3Start = true;
                        Debug.LogWarning("Player3 locked");
                        checks++;
                        break;
                    }
                    else if (i == player4contr)
                    {
                        player4Start = true;
                        Debug.LogWarning("Player4 locked");
                        checks++;
                        break;
                    }
                }
            }
        }
        if (controllers >= 2 && checks == controllers)
        {
            PlayerPrefs.SetInt("Nplayers", checks);
            //Once all players have locked you can change scene...

            SceneManager.LoadScene(sceneName);
        }
    }
}