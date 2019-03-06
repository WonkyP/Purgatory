using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponAttackStats
{
    // Stats of the weapon attacks
    [SerializeField]
    private float weapon_Power;
    public float Weapon_Power { get { return this.weapon_Power; } }
}
