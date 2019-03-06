using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct OneHandedWeaponStats
{
    // Stats of the one-handed weapon
    [SerializeField]
    private float velocity;
    public float Velocity { get { return this.velocity; } }
}
