﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMTesting : MonoBehaviour
{

    public static GMTesting instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buutonAction(string action)
    {
        if(action == "Play")
        {
            Debug.Log("PlayButtonPressed");
            //SceneManager.LoadScene("CameraPrototypeAndMovement");
        }
    }
}
