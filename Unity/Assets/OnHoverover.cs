using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverover : MonoBehaviour
{
    private void OnMouseEnter()
    {
        print("HighLighted");
    }

    private void OnMouseExit()
    {
        print("No hightlight");
    }
}
