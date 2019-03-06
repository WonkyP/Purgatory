using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItems
{
    // CLASS ATTRIBUTES

    // A tag to know the item
    [SerializeField]
    private string tag;
    public string Tag { get { return this.tag; } }

    // An id to identify the item
    [SerializeField]
    private int id;
    public int Id { get { return this.id; } }

    // An image for the object
    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return this.image; } }

    // A description of the object
    [SerializeField]
    private string description;
    public string Description { get { return this.description; } }

    // Constructor of the class
    public InventoryItems(string t, int Id)
    {
        this.tag = t;
        this.id = Id;
    }
}
