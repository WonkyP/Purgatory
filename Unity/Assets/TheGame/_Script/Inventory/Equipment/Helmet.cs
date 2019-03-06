using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Helmet : InventoryItems
{
    // Constructor for the class
    public Helmet(string t, int Id) : base(t, Id)
    {
    }

    // Struct with the stats
    [SerializeField]
    private HelmetStats helmetStats;
    public HelmetStats HelmetStats_ { get { return this.helmetStats; } }
}
