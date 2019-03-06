using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ChestStats
{
    [SerializeField]
    private float resistance;
    public float Resistance { get { return this.resistance; } }
}
