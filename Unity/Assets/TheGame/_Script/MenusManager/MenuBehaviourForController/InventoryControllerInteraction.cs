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

    public string dPadInputVertical = "" ;
    public string dpadInputHorizontal = "";

    public string selectionButton = "";
    public string undoButton = "";

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


    private bool[,] booleanMatrix;

    // Start is called before the first frame update
    void Start()
    {
        cols[c].fils[f].color = Color.yellow;
        maxC = maxF = cols.Count;

        booleanMatrix = new bool[maxF, maxC];

        axisInputManager();
        dPadInput();
        selectInput();
        undoInput();
    }


    public float verticalAxis = 0;
    public float horizontalAxis = 0;
    bool verticalPressed = false;
    bool horizontalPressed = false;
    // Update is called once per frame
    void Update()
    {



        verticalAxis = Input.GetAxisRaw(dPadInputVertical);
        horizontalAxis = Input.GetAxisRaw(dpadInputHorizontal);

        verticalAxis -= Input.GetAxis(controllerVerticalInput);
        horizontalAxis += Input.GetAxis(controllerHorizontalInput);



        //for controllers on the final build
        try
        {
            if (hInput.GetButtonDown(selectionButton))
            {
                cols[c].fils[f].color = Color.red;
                booleanMatrix[c, f] = true;
            }

            if (hInput.GetButtonDown(undoButton))
            {
                cols[c].fils[f].color = Color.yellow;
                booleanMatrix[c, f] = false;
            }
        }
        catch
        {

        }

        try
        {
            if (Input.GetButtonDown(selectionButton))
            {
                cols[c].fils[f].color = Color.red;
                booleanMatrix[c, f] = true;
            }

            if (Input.GetButtonDown(undoButton))
            {
                cols[c].fils[f].color = Color.yellow;
                booleanMatrix[c, f] = false;
            }
        }
        catch { }


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
                if (!booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.white;
                else cols[c].fils[f].color = Color.red;


                verticalPressed = true;
                f++;
                fixFilsIndex();

                if (booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.magenta;
                else cols[c].fils[f].color = Color.yellow;
            }
        }
        else if (verticalAxis < -inputLevel)
        {
            if (!verticalPressed)
            {
                if (!booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.white;
                else cols[c].fils[f].color = Color.red;

                verticalPressed = true;
                f--;
                fixFilsIndex();

                if (booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.magenta;
                else cols[c].fils[f].color = Color.yellow;
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
                if (!booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.white;
                else cols[c].fils[f].color = Color.red;

                horizontalPressed = true;
                c++;
                fixColIndex();

                if (booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.magenta;
                else cols[c].fils[f].color = Color.yellow;
            }
        }
        else if (horizontalAxis < -inputLevel)
        {
            if (!horizontalPressed)
            {
                if (!booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.white;
                else cols[c].fils[f].color = Color.red;

                horizontalPressed = true;
                c--;
                fixColIndex();

                if (booleanMatrix[c, f])
                    cols[c].fils[f].color = Color.magenta;
                else cols[c].fils[f].color = Color.yellow;
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

    void dPadInput()
    {
        dPadInputVertical = "DpadVertical" + isDS4 + pNumber.ToString() ;
        dpadInputHorizontal = "DpadHorizontal" + isDS4 + pNumber.ToString();
     }


    void selectInput()
    {
        if (TestingWithKeyBoard)
        {
            selectionButton = "attack1K";
        }
        else if (TestingWithPs4Controller)
        {
            selectionButton = "selectPs4Test";
        }
        else if (TestingWithXboxController)
        {
            selectionButton = "selectXboxTest";
        }
        else
        {
            selectionButton = "A" + isDS4 + pNumber.ToString();
        }
    }

    void undoInput()
    {
        if (TestingWithKeyBoard)
        {
            undoButton = "attack2K";
        }
        else if (TestingWithPs4Controller)
        {
            undoButton = "dashPs4Test";
        }
        else if (TestingWithXboxController)
        {
            undoButton = "dashXboxTest";
        }
        else
        {
            undoButton = "B" + isDS4 + pNumber.ToString();
        }
    }

}
