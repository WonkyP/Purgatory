using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryControllerInteraction : MonoBehaviour
{
    //[SerializeField]
    //public List<Image> fils;
    [System.Serializable]
    public class Custom
    {
        public List<Image> images;
    }

    public List<Custom> inventario;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
