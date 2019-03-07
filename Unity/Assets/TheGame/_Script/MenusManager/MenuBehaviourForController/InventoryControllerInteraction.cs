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
    }


    float verticalAxis = 0;
    float horizontalAxis = 0;
    bool verticalPressed = false;
    bool horizontalPressed = false;
    // Update is called once per frame
    void Update()
    {

        verticalAxis = Input.GetAxisRaw("DpadVerticalPSTest");
        horizontalAxis = Input.GetAxisRaw("DpadHorizontalPSTest");


        verticalInput();
        horizontalInput();


    }

    void verticalInput()
    {
        if (verticalAxis > 0)
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
        else if (verticalAxis < 0)
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
        if (horizontalAxis > 0)
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
        else if (horizontalAxis < 0)
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
}
