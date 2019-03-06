using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponItems
{
    // One-handed weapons
    private string oneHandedWeaponsKey;
    public string OneHandedWeaponsKey { get { return this.oneHandedWeaponsKey; } set { this.oneHandedWeaponsKey = value; } }

    [SerializeField]
    private List<OneHandedWeapon> oneHandedWeapons;
    public List<OneHandedWeapon> OneHandedWeapons { get { return this.oneHandedWeapons; } }


    // Two-handed weapons
    private string twoHandedWeaponsKey;
    public string TwoHandedWeaponsKey { get { return this.twoHandedWeaponsKey; } set { this.twoHandedWeaponsKey = value; } }

    [SerializeField]
    private List<TwoHandedWeapon> twoHanedWeapons;
    public List<TwoHandedWeapon> TwoHanedWeapons { get { return this.twoHanedWeapons; } }
}
