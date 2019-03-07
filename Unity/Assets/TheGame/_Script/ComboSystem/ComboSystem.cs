using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private PlayerManager playerManager_;
    private Animator animator_;
    

    private void Start()
    {
        playerManager_ = GetComponent<PlayerManager>();
        animator_ = GetComponent<Animator>();
    }

    public void addAttackToCombo(Queue<Weapon_Attack> comboSet, Weapon_Attack attack)
    {
        if (comboSet.Count < 5)
        {
            //attack.ComboNumber = comboSet.Count;
            comboSet.Enqueue(attack);
        }
        
    }

    public void removeAttackFromCombo(Queue<Weapon_Attack> comboSet, int attackId)
    {
        Weapon_Attack a = findAttack(comboSet, attackId);
        comboSet.Dequeue();
        //a = playerManager_.DefaulWeaponAttack;
        //comboSet.Enqueue(a);

    }

    private Weapon_Attack findAttack(Queue<Weapon_Attack> comboSet, int attackId)
    {
        Weapon_Attack attack;

        while (comboSet.Peek().Id != attackId)
        {
            attack = comboSet.Dequeue();
            comboSet.Enqueue(attack);
        }

        attack = comboSet.Peek();

        return attack;
    }

    public void executeComboSet(Queue<Weapon_Attack> comboSet)
    {
        Weapon_Attack comboAttack = comboSet.Dequeue();
        animator_.SetTrigger(comboAttack.AttackAnimation);
        comboSet.Enqueue(comboAttack);

        Debug.Log(comboAttack.Tag + " executed");
    }

    public void advanceComboSet(Queue<Weapon_Attack> comboSet)
    {
        Weapon_Attack comboAttack = comboSet.Dequeue();
        comboSet.Enqueue(comboAttack);
    }

    public void restartCombo(Queue<Weapon_Attack> comboSet)
    {
        while (comboSet.Peek().ComboNumber != 0)
        {
            Weapon_Attack attack = comboSet.Dequeue();
            comboSet.Enqueue(attack);
        }
    }

    public void setComboOrder(Queue<Weapon_Attack> comboSet)
    {
        int i = 0;
        Weapon_Attack attack;

        while (i < comboSet.Count)
        {
            attack = comboSet.Dequeue();
            attack.ComboNumber = i;
            comboSet.Enqueue(attack);

            i++;
        }

    }
}
