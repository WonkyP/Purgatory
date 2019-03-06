using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public RectTransform healthBar;

    public int maxHealth = 100;
    int damageReceived = 10;
    int health;

    public bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            takeDamage();
            damaged = !damaged;
        }
    }

    public void takeDamage()
    {
        health -= damageReceived;

        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }
}
