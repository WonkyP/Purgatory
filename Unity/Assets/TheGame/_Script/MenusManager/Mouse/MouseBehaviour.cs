using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseBehaviour : MonoBehaviour
{

    [Range(1.0f, 10.0f)]
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(new Vector2(Input.GetAxis("Horizontal1Test") * moveSpeed, Input.GetAxis("Vertical1Test") * moveSpeed));
        if (Input.GetButtonDown("attack1XboxTest"))
        {
            Debug.Log("boton_pulsado");
            Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.tag);
            }
        }
    }

    private void LateUpdate()
    {

    }

    
}
