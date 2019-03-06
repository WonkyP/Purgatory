using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDamage : MonoBehaviour
{

    public PlayerClass Dummy;

public void TakeDamage( float damage )
    {
        float AfterArmoreAdd = damage - Dummy.Def; // Should get from playerManager

        if (AfterArmoreAdd <= 0) // checks if damage were delt
        {
            Debug.Log("0 Damage, you are too weak");
            return;
        }

        Dummy.HP -= AfterArmoreAdd;

        // Dead or not
    }
}