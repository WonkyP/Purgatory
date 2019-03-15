using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShitCode : MonoBehaviour
{
    private static CanvasShitCode instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
