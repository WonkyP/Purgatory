using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TwoHandedWeapon : InventoryItems
{
    // Constructor of the class
    public TwoHandedWeapon(string t, int Id) : base(t, Id)
    {
    }

    // Struct with the stats
    [SerializeField]
    private TwoHandedWeaponStats twoHandedWeaponStats;
    public TwoHandedWeaponStats TwoHandedWeaponStats { get { return this.twoHandedWeaponStats; } }
}
