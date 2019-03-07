using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private PlayerManager playerManager;

    public RectTransform topHeadHealthBar;
    public RectTransform mainHelathBar;

    public int maxHealth = 100;
    int damageReceived = 10;
    int health;

    public bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Testung
        if (damaged)
        {
            takeDamage(10);
            damaged = !damaged;
        }
        ///////////////
    }

    public void takeDamage(int damageReceived)
    {
        health -= damageReceived;

        topHeadHealthBar.sizeDelta = new Vector2(health * 2, topHeadHealthBar.sizeDelta.y);
        mainHelathBar.sizeDelta = new Vector2(health * 2, topHeadHealthBar.sizeDelta.y);

        GameManager.instance.takeDamage(health, playerManager.Player_id);

    }
}
