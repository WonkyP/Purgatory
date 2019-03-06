using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private bool vertical;

    Camera player1Camera;
    Camera player2Camera;

    public Camera[] activeCameras;


    public bool Vertical // property, it is called when the variable itself is changed
    {
        get { return vertical; }
        set
        {
            if (value == vertical)     // if it is not changed returns, if not , it sets the value as the new one and calls the method behind
                return;

            vertical = value;
            ModifyCameraDisplay(vertical);
        }
    }

    void Start()
    {
        activeCameras = GetComponentsInChildren<Camera>();// take tha cameras on the camera setting object and save a reference to them to work with them

        player1Camera = activeCameras[0];
        player2Camera = activeCameras[1];

        ModifyCameraDisplay(Vertical); //Set the default values of the screeen to horizontal mode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Vertical = !Vertical; // cahnges the variable when the button v is pressed
        }
    }

    

    void ModifyCameraDisplay(bool vertical)
    {
        if (vertical) // it changes the offset of the cameras depending on the offset selected;
        {

            player1Camera.rect = new Rect(0, 0, 0.5f, 1);
            player2Camera.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
        else
        {
            player1Camera.rect = new Rect(0, 0.5f, 1, 0.5f);
            player2Camera.rect = new Rect(0, 0.0f, 1, 0.5f);
        }
    }

    
}
