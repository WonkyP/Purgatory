using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{

    public static PlayerDataHandler instance;

    private Queue<Weapon_Attack> player1ComboSet1 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> Player1ComboSet1 { get { return this.player1ComboSet1; } set { this.player1ComboSet1 = value; } }

    private Queue<Weapon_Attack> player1ComboSet2 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> Player1ComboSet2 { get { return this.player1ComboSet2; } set { this.player1ComboSet2 = value; } }

    private Queue<Weapon_Attack> player2ComboSet1 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> Player2ComboSet1 { get { return this.player2ComboSet1; } set { this.player2ComboSet1 = value; } }

    private Queue<Weapon_Attack> player2ComboSet2 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> Player2ComboSet2 { get { return this.player2ComboSet2; } set { this.player2ComboSet2 = value; } }


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public Queue<Weapon_Attack> getComboSet1(int playerId)
    {
        if (playerId == 1)
            return Player1ComboSet1;
        else
            return player2ComboSet1;
    }

    public void saveComboSet1(int playerId, Queue<Weapon_Attack> comboset1)
    {
        if (playerId == 1)
            player1ComboSet1 = comboset1;
        else
            player2ComboSet2 = comboset1;
    }
}
