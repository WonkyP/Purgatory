using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HelmetStats
{
    [SerializeField]
    private float strength;
    public float Strength { get { return this.strength; } }
}