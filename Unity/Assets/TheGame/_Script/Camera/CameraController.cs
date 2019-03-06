using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Transform tagetParent;

    public Player player;
    InputCameraManager cameraManager;

    float smoothLevel = 100;


    float cameraOffsetX;
    [Range(-5.0F, 5.0F)]
    public float cameraOffsetY; // -0.08
    [Range(0.5F, 5.0F)]
    public float cameraOffsetZ; // 1.7

    float cameraOffsetZDeffault = 1.7f;
    float cameraOffsetYDeffault = -0.08f;

    public bool returnToDefault;

    Vector3 offset;

    float maxAngle = 45;
    float minAngle = 60;

    [Range(0.0f, 10.0f)]
    public float horizontalRotationSpeed = 2;

    [Range(0.0f, 10.0f)]
    public float verticalRotationSpeed = 1;


    public Transform pivot;

    public bool invertedY = false;
    string controller = "";


    string verticalInput;
    string horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

        tagetParent = target.transform.parent;

        offset = target.position - transform.position;

        //cameraOffsetX = offset.x;
        //cameraOffsetY = offset.y;
        //cameraOffsetZ = offset.z;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        player = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<Player>();//we get acces to the player
        cameraManager = GetComponent<InputCameraManager>();
    }




    private void Update()
    {

        if (returnToDefault)
        {
            cameraOffsetY = cameraOffsetYDeffault;
            cameraOffsetZ = cameraOffsetZDeffault;
            returnToDefault = false;
        }

        offset = new Vector3(cameraOffsetX, cameraOffsetY,cameraOffsetZ);
    }

    // Update is called once per frame
    void LateUpdate()
    {
            float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis(cameraManager.cameraHorizontalInput ), Input.GetAxis(cameraManager.cameraVerticalInput));
        if (stickInput.magnitude < deadzone)
                stickInput = Vector2.zero;
            else
                stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

            float horizontal = stickInput.x * horizontalRotationSpeed;

            tagetParent.Rotate(0, horizontal, 0);

        //get the y position of the mouse and rotates the pivot 
        float vertical = stickInput.y * verticalRotationSpeed;

            //
            if (invertedY)
            {
                vertical = -vertical;
            }

            pivot.Rotate(vertical, 0, 0);

            if (pivot.rotation.eulerAngles.x > maxAngle && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxAngle, 0, 0);
            }

            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f - minAngle)
            {
                pivot.rotation = Quaternion.Euler(360f - minAngle, 0, 0);
            }

            float desireAngleY = target.eulerAngles.y;
            float desireAngleX = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desireAngleX, desireAngleY, 0);


            transform.position = Vector3.Lerp(
                        transform.position, target.position - (rotation * offset), Time.deltaTime * smoothLevel);


            if (transform.position.y < target.transform.position.y - 0.5f)
            {
                transform.position = new Vector3(transform.position.x, target.transform.position.y - 0.5f, transform.position.z);
            }

            transform.LookAt(target);
    }
    /// <summary>
    /// Método que hace la actualización de la posición, mirando la posición del target
    /// y cambiando (suavizando) la posición de la cámara.
    /// </summary>
}
