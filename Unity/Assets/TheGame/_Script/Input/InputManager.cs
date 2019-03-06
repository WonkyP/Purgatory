using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public string controllerHorizontalInput;
    public string controllerVerticalInput;

    //private string dashInput;
    //public string DashInput { get { return this.dashInput; } }


    private string dashInput;
    public string DashInput { get { return this.dashInput; } }

    private string attackInput1;
    public string AttackInput1 { get { return this.attackInput1; } }

    private string attackInput2;
    public string AttackInput2 { get { return this.attackInput2; } }


    Player player;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        player = GetComponent<Player>();
        axisInputManager();
        dashInputManager();
        attackInputManager();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////public string returnDashInputString()
    ////{
    ////    return dashInput;
    ////}

    ////public string returnAttack_1_InputString()
    ////{
    ////    return attackInput1;
    ////}

    ////public string returnAttack_2_InputString()
    ////{
    ////    return attackInput2;
    ////}

    void dashInputManager()
    {
        if (player.TestingWithKeyBoard)
        {
            dashInput = "dashK";
        }
        else if (player.TestingWithPs4Controller)
        {
            dashInput = "dashPs4Test";
        }
        else if (player.TestingWithXboxController)
        {
            dashInput = "dashXboxTest";
        }
        else
        {
            dashInput = "B"+ player.isDS4 + player.pNumber.ToString();
        }
    }


    void attackInputManager()
    {
        if (player.TestingWithKeyBoard)
        {
            attackInput1 = "attack1K";
            attackInput2 = "attack2K";
        }
        else if (player.TestingWithPs4Controller)
        {
            attackInput1 = "attack1Ps4Test";
            attackInput2 = "attack2Ps4Test";
        }
        else if (player.TestingWithXboxController)
        {
            attackInput1 = "attack1XboxTest";
            attackInput2 = "attack2XboxTest";
        }
        else
        {
            attackInput1 = "X" + player.isDS4 + player.pNumber.ToString();
            attackInput2 = "Y" + player.pNumber.ToString();
        }
    }

    void axisInputManager()
    {

        if (player.TestingWithKeyBoard)
        {
            controllerHorizontalInput = "HorizontalK";
            controllerVerticalInput = "VerticalK";
        }
        else if (player.TestingWithPs4Controller || player.TestingWithXboxController)
        {
            controllerHorizontalInput = "Horizontal1Test";
            controllerVerticalInput = "Vertical1Test";
        }
        else
        {
            controllerHorizontalInput = "Horizontal" + player.pNumber.ToString();
            controllerVerticalInput = "Vertical" + player.pNumber.ToString();
        }
    }
}
