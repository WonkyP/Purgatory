using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ArmStats
{
    [SerializeField]
    private float hardness;
    public float Hardness { get { return this.hardness; } }
}
