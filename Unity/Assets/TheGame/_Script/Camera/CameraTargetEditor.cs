using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetEditor : MonoBehaviour
{
    [SerializeField]
    private Transform cameraT;

    [SerializeField]
    [Range(-10.0f, 10.0f)]
    private float cameraTHeight;
    // Start is called before the first frame update
    void Start()
    {
        cameraTHeight = cameraT.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraT.localPosition = new Vector3(cameraT.localPosition.x, cameraTHeight, cameraT.localPosition.z);
    }
}
