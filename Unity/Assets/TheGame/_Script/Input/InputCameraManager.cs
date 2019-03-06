using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCameraManager : MonoBehaviour
{



    public string cameraHorizontalInput;
    public string cameraVerticalInput;

    Player player;

    // Start is called before the first frame update
    void Start()
    {

        player = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<Player>();//we get acces to the player 

        if (player.TestingWithKeyBoard)
        {
            cameraHorizontalInput = "Mouse X";
            cameraVerticalInput = "Mouse Y";
        }
        else if (player.TestingWithPs4Controller)
        {
            cameraHorizontalInput = "RHorizontal1Ps4Test";
            cameraVerticalInput = "RVertical1Ps4Test";
        }
        else if (player.TestingWithXboxController)
        {
            cameraHorizontalInput = "RHorizontal1Test";
            cameraVerticalInput = "RVertical1Test";
        }
        else
        {
            cameraHorizontalInput = "RHorizontal" + player.isDS4 + player.pNumber.ToString();
            cameraVerticalInput = "RVertical" + player.isDS4 + player.pNumber.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
