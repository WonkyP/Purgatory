using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chest : InventoryItems
{
    // Constructor of the class
    public Chest(string t, int Id) : base(t, Id)
    {
    }

    // Struct with the stats
    [SerializeField]
    private ChestStats chestStats;
    public ChestStats ChestStats_ { get { return this.chestStats; } }
}
