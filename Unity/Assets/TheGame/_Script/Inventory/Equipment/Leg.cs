using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leg : InventoryItems
{
    // Constructor of the class
    public Leg(string t, int Id) : base(t, Id)
    {
    }

    // Struct with the stats
    [SerializeField]
    private LegStats legStats;
    public LegStats LegStats_ { get { return this.legStats; } }
}
