using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryControllerInteraction : MonoBehaviour
{
    //[SerializeField]
    //public List<Image> fils;
    int f = 0;
    int c = 0;




    public string controllerHorizontalInput;
    public string controllerVerticalInput;

    public int pNumber = 0;
    public string isDS4 = "";

    float inputLevel = 0;

    public bool TestingWithKeyBoard;
    public bool TestingWithXboxController;
    public bool TestingWithPs4Controller;




    public int maxC;
    int maxF;

    [System.Serializable]
    public class Custom
    {
        public List<Image> fils;
    }

    public List<Custom> cols;


    // Start is called before the first frame update
    void Start()
    {
        cols[c].fils[f].color = Color.yellow;
        maxC = maxF = cols.Count;

        axisInputManager();
    }


    public float verticalAxis = 0;
    public float horizontalAxis = 0;
    bool verticalPressed = false;
    bool horizontalPressed = false;
    // Update is called once per frame
    void Update()
    {

        verticalAxis = Input.GetAxisRaw("DpadVerticalPSTest");
        horizontalAxis = Input.GetAxisRaw("DpadHorizontalPSTest");

        try
        {
            verticalAxis -= Input.GetAxis(controllerVerticalInput);
            horizontalAxis += Input.GetAxis(controllerHorizontalInput);
        }
        catch
        {
            Debug.Log("Not input detection");
        }

        //try
        //{
        //    verticalAxis = hInput.GetAxis(controllerVerticalInput);
        //    horizontalAxis = hInput.GetAxis(controllerHorizontalInput);
        //}
        //catch
        //{
        //    Debug.Log("Not HHHHinput detection");
        //}




        verticalInput();
        horizontalInput();


    }

    void verticalInput()
    {
        if (verticalAxis > inputLevel)
        {
            if (!verticalPressed)
            {
                cols[c].fils[f].color = Color.white;
                verticalPressed = true;
                f++;
                fixFilsIndex();
                cols[c].fils[f].color = Color.yellow;
            }
        }
        else if (verticalAxis < -inputLevel)
        {
            if (!verticalPressed)
            {
                cols[c].fils[f].color = Color.white;
                verticalPressed = true;
                f--;
                fixFilsIndex();
                cols[c].fils[f].color = Color.yellow;
            }
        }
        else verticalPressed = false;
    }

    void horizontalInput()
    {
        if (horizontalAxis > inputLevel)
        {
            if (!horizontalPressed)
            {
                cols[c].fils[f].color = Color.white;
                horizontalPressed = true;
                c++;
                fixColIndex();
                cols[c].fils[f].color = Color.yellow;
            }
        }
        else if (horizontalAxis < -inputLevel)
        {
            if (!horizontalPressed)
            {
                cols[c].fils[f].color = Color.white;
                horizontalPressed = true;
                c--;
                fixColIndex();
                cols[c].fils[f].color = Color.yellow;
            }
        }
        else horizontalPressed = false;
    }


    void fixColIndex()
    {
        if (c < 0) c = maxC - 1;
        else if (c >= maxC) c = 0;
    }
    void fixFilsIndex()
    {
        if (f < 0) f = maxF - 1;
        else if (f >= maxF) f = 0;
    }


    void axisInputManager()
    {

        if (TestingWithKeyBoard)
        {
            controllerHorizontalInput = "HorizontalK";
            controllerVerticalInput = "VerticalK";
            
        }
        else if (TestingWithPs4Controller || TestingWithXboxController)
        {
            controllerHorizontalInput = "Horizontal1Test";
            controllerVerticalInput = "Vertical1Test";
            inputLevel = 0.5f;
        }
        else
        {
            controllerHorizontalInput = "Horizontal" + pNumber.ToString();
            controllerVerticalInput = "Vertical" + pNumber.ToString();
            inputLevel = 0.5f;
        }
    }


}
