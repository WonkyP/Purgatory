using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public Player PlayerScript;
    int playerId;

    // Start is called before the first frame update
    void Start()
    {
        playerId = PlayerScript.Player_Id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player pS = other.GetComponent<Player>();
            if (pS.Player_Id != playerId)
            {
                Debug.Log("hit an enemie");
                pS.GettingHit(20f);
            }
        }
    }

}
