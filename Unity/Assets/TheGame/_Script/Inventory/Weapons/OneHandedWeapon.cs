using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OneHandedWeapon : InventoryItems
{
    // Constructor of the class
    public OneHandedWeapon(string t, int Id) : base(t, Id)
    {
    }

    // Struct with the stats
    [SerializeField]
    private OneHandedWeaponStats oneHandedWeaponStats;
    public OneHandedWeaponStats OneHandedWeaponStats { get { return this.oneHandedWeaponStats; } }
}
