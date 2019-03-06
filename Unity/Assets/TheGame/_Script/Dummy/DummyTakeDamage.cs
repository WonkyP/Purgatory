using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTakeDamage : MonoBehaviour
{
    float maxHealth;
    public float hp = 1000;
    public float hpRegain = 50;

    private void Start()
    {
        maxHealth = hp;
    }

    private void FixedUpdate()
    {
        if (hp < maxHealth) 
        {
            hp += hpRegain * Time.deltaTime;
        }
    }

    public void TakeDamage(Card atk)
    {
        hp -= atk.damage;
        if (hp <= 0)
        {
            print("Dummy has: " + hp + "/" + maxHealth + " Life left!");
            print("You killed the Dummy! The mighty dummy used full heal.");
            hp = maxHealth;
        }
        else
        {
            print("Dummy has: " + hp + "/" + maxHealth + " Life left!");
        }
    }
}
