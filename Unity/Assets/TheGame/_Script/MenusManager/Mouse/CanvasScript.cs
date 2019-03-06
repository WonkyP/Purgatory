using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;


    bool cardSelected = false;

    public GameObject fakeMouse;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {



        //Check if the left Mouse button is clicked
        if (Input.GetButtonDown("attack2XboxTest"))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = fakeMouse.transform.position;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {


                if (result.gameObject.tag == "AaronTestTag")
                {

                    if (!cardSelected)
                    {
                        result.gameObject.GetComponent<AaronTestCard>().selectedCard();
                        result.gameObject.transform.SetParent(fakeMouse.transform);
                        cardSelected = true;
                    }
                    else
                    {
                        result.gameObject.transform.SetParent(this.transform);
                        cardSelected = false;
                    }
                }


                else if (result.gameObject.tag == "Button")
                {
                    result.gameObject.GetComponent<TestingButton>().buttonPressed();
                }
            }
        }
    }
}
