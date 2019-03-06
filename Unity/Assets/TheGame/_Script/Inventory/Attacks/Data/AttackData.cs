using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : InventoryItems
{
    [SerializeField]
    private string attackAnimation;
    public string AttackAnimation { get { return this.attackAnimation; } }

    private int comboNumber;
    public int ComboNumber { get { return this.comboNumber; } set { this.comboNumber = value; } }


    // Constructor of the class
    public AttackData(string t, int Id, string atkAnimation) : base(t, Id)
    {
        attackAnimation = atkAnimation;
    }



}
