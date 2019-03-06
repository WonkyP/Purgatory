
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoNotDestroy : MonoBehaviour
{

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

    }



    void Awake() // only happens when the object is in the scene from before
    {
        GameObject[] theObject;
        theObject = GameObject.FindGameObjectsWithTag("DoNotDestroy"); // fid all the objects

        DontDestroyOnLoad(this.gameObject); // don't destroy this object

        if (theObject.Length != 0) // check if theres more then one object
        {
            for (int i = 0; i < theObject.Length; i++)
            {
                if (i == 0)
                {
                    // just checks if its the first object of the list
                }
                else
                {
                    Destroy(theObject[i]);// destroy everything else

                }
            }
        }
    }
}

