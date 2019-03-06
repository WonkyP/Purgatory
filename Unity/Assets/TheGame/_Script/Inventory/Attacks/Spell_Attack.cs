using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell_Attack : AttackData
{
    // Constructor of the cards
    public Spell_Attack(string t, int Id, string atkAnimation) : base(t, Id, atkAnimation)
    {
    }

    // Struct with the stats
    [SerializeField]
    private SpellAttackStats spellAttackStats;
    public SpellAttackStats SpellAttackStats { get { return this.spellAttackStats; } }
}
