using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private bool vertical;

    Camera player1Camera;
    Camera player2Camera;

    //public Camera[] activeCameras;

    private GameObject mainHealthCanvas;
    public GameObject MainHealthCanvas { get { return this.mainHealthCanvas; } }

    private GameObject player1;
    private PlayerSystem player1System;

    private GameObject player2;
    private PlayerSystem player2System;

    private static SplitScreen instance;


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

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);


        mainHealthCanvas = transform.Find("MainHealthCanvas").gameObject;
        player1 = transform.Find("Player1System").gameObject;
        player2 = transform.Find("Player2System").gameObject;

        player1System = player1.GetComponent<PlayerSystem>();
        player2System = player2.GetComponent<PlayerSystem>();

    }

    void Start()
    {
        //activeCameras = GetComponentsInChildren<Camera>();// take tha cameras on the camera setting object and save a reference to them to work with them

        player1Camera = player1System.PlayerCamera.GetComponent<Camera>();
        player2Camera = player2System.PlayerCamera.GetComponent<Camera>();

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
