using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private PlayerManager playerManager_;

    [SerializeField]
    private Animator animator_;
    

    private void Start()
    {
        playerManager_ = GetComponent<PlayerManager>();
    }

    // InventoryMethods
    public void addAttackToCombo(List<Weapon_Attack> currentComboSet, Weapon_Attack attack)
    {
        if (currentComboSet.Count < 5)
        {
            //attack.ComboNumber = comboSet.Count;
            currentComboSet.Add(attack);
        }
    }

    public void removeAttackFromCombo(List<Weapon_Attack> currentComboSet, Weapon_Attack attack)
    {
        currentComboSet.Remove(attack);
    }

    public void emptyCombos(List<Weapon_Attack> currentComboSet, Queue<Weapon_Attack> comboset)
    {
        currentComboSet.Clear();
        comboset.Clear();
    }

    public void createComboQueue(List<Weapon_Attack> currentComboSet, Queue<Weapon_Attack> comboSet)
    {
        Weapon_Attack attack;
        for (int i = 0; i < currentComboSet.Count; i++)
        {
            attack = currentComboSet[i];
            attack.ComboNumber = i;
            comboSet.Enqueue(attack);
        }
    }

    // Methods in-game
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

}
