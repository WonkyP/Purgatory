using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpellAttackStats
{
    // Stats of the spell attacks
    [SerializeField]
    private float magic_Power;
    public float Magic_Power { get { return this.magic_Power; } }
}
