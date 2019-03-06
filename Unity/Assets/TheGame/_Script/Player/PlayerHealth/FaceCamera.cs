using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    public Camera enemyPlayerCamera;

    private void LateUpdate()
    {
        transform.LookAt(enemyPlayerCamera.transform);
    }
}
