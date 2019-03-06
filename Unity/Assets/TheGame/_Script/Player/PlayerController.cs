using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;
    public float gravityScale;
    // Start is called before the first frame update

    public Vector3 movementDirection;

    public float X;
    public float Y;

    public Vector3 Drag;
    public float DashDistance;
    public bool dashing = false;

    public float smoothLevel;

    Vector3 newPosition;

    // PLACEHOLDER FOR ATTACKS
    public WeaponDealDamage WDD;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashing)//instead of this we are going to have a state machine, so this boolean is not going to be necesary
        {
            //movementDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0.0f, Input.GetAxis("Vertical")*moveSpeed);

            //TRY TO USE TWO DIFFRENT VARIABLES IN ORDER TO KEEP THAT INFORMATION AND CAN USE IT TO THE DODGE HABILITY
            movementDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed);

            movementDirection.y = movementDirection.y + gravityScale * (Physics.gravity.y * Time.deltaTime);

            // GONNA PUT PLACEHOLDER CODE HERE
            if (movementDirection.x != 0 || movementDirection.z != 0)
            {
                transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", true);
                transform.GetChild(0).GetComponent<Animator>().SetFloat("WalkingSpeed", movementDirection.z);

            }
            else
            {

                transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", false);

            }

            if (Input.GetButtonDown("Fire1"))
            {
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
                ////////////////WDD.Attack(new Vector2(0.12f , 0.5f));
            }

        }

        if (Input.GetButtonDown("Dash"))
        { //we cahnge the state to dash state
            if (movementDirection.x == 0 && movementDirection.z == 0)
            {//needs to be refinde to be activate only when the player is not pressing, the movement takes a little long than the pressing
                newPosition = transform.position + transform.forward * DashDistance;
                dashing = true;
            }
            else
            {
                Vector3 forwardMovement = transform.forward * Input.GetAxis("Vertical");
                Vector3 sideMovement = transform.right * Input.GetAxis("Horizontal");
                Vector3 dahsDirection = sideMovement + forwardMovement;
                newPosition = transform.position + dahsDirection.normalized * DashDistance;
                dashing = true;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////
        controller.Move(movementDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag != "Floor")
            {
                newPosition = transform.position;
                dashing = false;
            }

    }

    private void FixedUpdate()
    {

        if (dashing)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothLevel);
            if (transform.position.x > newPosition.x - 0.2 && transform.position.x < newPosition.x + 0.2 && transform.position.z > newPosition.z - 0.2 && transform.position.z < newPosition.z + 0.2)
            {
                dashing = false; // will return the state to movement state
            }
        }

        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothLevel);
        //transform.position = Vector3.Lerp(
        //   transform.position, newPositionTransform.position, Time.deltaTime * smoothLevel);
    }
}
