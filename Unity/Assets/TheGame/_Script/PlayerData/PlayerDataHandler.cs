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


    // TESTING: CAN BE DELETED
    Weapon_Attack atk1_1 = new Weapon_Attack("Attack 1_Combo1", 1, "Sure Strike");
    Weapon_Attack atk2_1 = new Weapon_Attack("Attack 2_Combo1", 2, "Sloppy Stab");
    Weapon_Attack atk3_1 = new Weapon_Attack("Attack 3_Combo1", 3, "Lunge");
    Weapon_Attack atk4_1 = new Weapon_Attack("Attack 2_Combo1", 4, "Fisted Uppercut");
    Weapon_Attack atk5_1 = new Weapon_Attack("Attack 3_Combo1", 5, "Fervent Anger");

    Weapon_Attack atk1_2 = new Weapon_Attack("Attack 1_Combo2", 1, "Attack");
    Weapon_Attack atk2_2 = new Weapon_Attack("Attack 2_Combo2", 2, "Attack");
    Weapon_Attack atk3_2 = new Weapon_Attack("Attack 3_Combo3", 3, "Attack");

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        player1ComboSet1.Enqueue(atk1_1);
        player1ComboSet1.Enqueue(atk2_1);
        player1ComboSet1.Enqueue(atk3_1);
        player1ComboSet1.Enqueue(atk4_1);
        player1ComboSet1.Enqueue(atk5_1);

        player1ComboSet2.Enqueue(atk1_2);
        player1ComboSet2.Enqueue(atk2_2);
        player1ComboSet2.Enqueue(atk3_2);
    }

    public Queue<Weapon_Attack> getComboSet1(int playerId)
    {
        if (playerId == 1)
            return player1ComboSet1;
        else
            return player2ComboSet1;
    }

    public Queue<Weapon_Attack> getComboSet2(int playerId)
    {
        if (playerId == 1)
            return player1ComboSet2;
        else
            return player2ComboSet2;
    }

    public void saveComboSet1(int playerId, Queue<Weapon_Attack> comboset1)
    {
        if (playerId == 1)
            player1ComboSet1 = comboset1;
        else
            player2ComboSet1 = comboset1;
    }

    public void saveComboSet2(int playerId, Queue<Weapon_Attack> comboset2)
    {
        if (playerId == 1)
            player1ComboSet2 = comboset2;
        else
            player2ComboSet2 = comboset2;
    }
}
