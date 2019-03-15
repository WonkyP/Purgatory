using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public Player PlayerScript;
    int playerId;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        playerId = PlayerScript.Player_Id;
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player pS = other.GetComponent<Player>();
            if (pS.Player_Id != playerId)
            {
                col.enabled = false;
                pS.GettingHit(20f);
            }
        }
    }

}
