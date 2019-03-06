using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TwoHandedWeaponStats
{
    // Stats of the two-handed weapons
    [SerializeField]
    private float hardness;
    public float Hardness { get { return this.hardness; } }
}
