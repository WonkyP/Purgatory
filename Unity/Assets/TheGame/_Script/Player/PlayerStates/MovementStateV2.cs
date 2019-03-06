using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateV2 : MonoBehaviour
{

    public float inputX;
    public float inputZ;
    public Vector3 desireMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float speed;
    public float allowPlayerRotation;

    public Camera cam;
    public CharacterController characterController;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;

    public float moveSpeed = 5;

    public Player player;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //player = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<Player>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    void Update()
    {
        InputMagnitude();


    }

    private void playerMovement()
    {
        inputX = Input.GetAxis("Horizontal1Test" /*+ player.pNumber.ToString()*/);
   
        inputZ = Input.GetAxis("Vertical1Test" /*+ player.pNumber.ToString()*/);

        Vector3 forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0.0f;
        right.y = 0.0f;

        forward.Normalize();
        right.Normalize();

        desireMoveDirection = forward * inputZ + right * inputX;

        //////desireMoveDirection = new Vector3(inputX, 0.0f, inputZ);/* forward * inputZ + right * inputX;*/

        if (!blockRotationPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desireMoveDirection), desiredRotationSpeed);
        }

        characterController.Move(desireMoveDirection * moveSpeed * Time.deltaTime);
    }

    void InputMagnitude()
    {
        inputX = Input.GetAxis("Horizontal1Test" /*+ player.pNumber.ToString()*/);

        inputZ = Input.GetAxis("Vertical1Test" /*+ player.pNumber.ToString()*/);

        //inputX = Input.GetAxis("Horizontal_P1J");

        //inputZ = Input.GetAxis("Vertical_P1J");

        speed = new Vector2(inputX, inputZ).sqrMagnitude;

        if (speed > allowPlayerRotation)
        {
            playerMovement();
        }

    }

    ////public MovementStateV2(Player player) : base(player)
    ////{

    ////}

    ////public override void Tick()
    ////{

    ////}

    ////public override void OnStateEnter()
    ////{
    ////    cam = Camera.main;
    ////}

}
