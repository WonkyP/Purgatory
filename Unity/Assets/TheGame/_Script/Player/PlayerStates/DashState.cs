using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{


    Vector3 newPosition;
    Vector3 dashDirection_;
    float dashDistance_ = 3;

    public float smoothLevel = 5;

    public DashState(Player player, Vector3 dashDirection) : base(player)
    {
        dashDirection_ = dashDirection;
    }



    public override void Tick()
    {
        ///////////////////////////////////
        Vector3 raycastOrigin = new Vector3(player.transform.position.x, player.transform.position.y - 0.7f /*- player.transform.localScale.y*/, player.transform.position.z);
        Debug.DrawRay(raycastOrigin, dashDirection_, Color.red, dashDistance_);
        //////////////////////////////////

        player.transform.position = Vector3.Lerp(player.transform.position, newPosition, Time.deltaTime * smoothLevel);
        if (player.transform.position.x > newPosition.x - 0.2 && player.transform.position.x < newPosition.x + 0.2 && player.transform.position.z > newPosition.z - 0.2 && player.transform.position.z < newPosition.z + 0.2)
        {
            // will return the state to movement state
            player.SetState(new MovementState(player));
        }
    }

    public override void OnStateEnter()
    {
     
        if (dashDirection_.x > 0) // dash Right
        {
            player.Anim.SetTrigger("Dodge Right");
        }
        else if (dashDirection_.x < 0) // dash Left
        {
            player.Anim.SetTrigger("Dodge Left");
        }

        newPosition = player.transform.position;
        checkNewPosition();//check if the new position with the default sashdistance is reacheable with the default dodge distance

        newPosition = player.transform.position + dashDirection_.normalized * dashDistance_;
        //player.SetState(new MovementState(player));

        //method that calculates if the new position is accessible.


    }
    void checkNewPosition()
    {

        dashDistance_ = player.PlayerManager.DashDistance;

        RaycastHit hit;
        Vector3 raycastOrigin = new Vector3(player.transform.position.x, player.transform.position.y - 0.7f /*- player.transform.localScale.y +3f*/, player.transform.position.z);
        Ray playerRay = new Ray(raycastOrigin, dashDirection_);

        if (Physics.Raycast(playerRay, out hit, dashDistance_))
        {
            dashDistance_ = hit.distance - 0.5f; // if the suposed new position of the player is not recheable it will change the dashDistance to the correct one in front of the obstacle.
        }
    }
}
