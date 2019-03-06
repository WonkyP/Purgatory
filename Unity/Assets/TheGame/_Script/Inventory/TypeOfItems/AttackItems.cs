using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackItems
{

    // Weapon attacks
    private string weaponAttacksKey;
    public string WeaponAttacksKey { get { return this.weaponAttacksKey; } set { this.weaponAttacksKey = value; } }

    [SerializeField]
    private List<Weapon_Attack> weaponAttacks;
    public List<Weapon_Attack> WeaponAttacks { get { return this.weaponAttacks; } }


    // Spell attacks
    private string spellAttacksKey;
    public string SpellAttacksKey { get { return this.spellAttacksKey; } set { this.spellAttacksKey = value; } }

    [SerializeField]
    private List<Spell_Attack> spellAttacks;
    public List<Spell_Attack> SpellAttacks { get { return this.spellAttacks; } }
}
