using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EquipmentItems
{
    // Helmets
    private string helmetsKey;
    public string HelmetsKey { get { return this.helmetsKey; } set { this.helmetsKey = value; } }

    [SerializeField]
    private List<Helmet> helmets;
    public List<Helmet> Helmets { get { return this.helmets; } }

    
    // Arms
    private string armsKey;
    public string ArmsKey { get { return this.armsKey; } set { this.armsKey = value; } }

    [SerializeField]
    private List<Arm> arms;
    public List<Arm> Arms { get { return this.arms; } }

    
    // Chests
    private string chestsKey;
    public string ChestsKey { get { return this.chestsKey; } set { this.chestsKey = value; } }

    [SerializeField]
    private List<Chest> chests;
    public List<Chest> Chests { get { return this.chests; } }

    
    // Legs
    private string legsKey;
    public string LegsKey { get { return this.legsKey; } set { this.legsKey = value; } }

    [SerializeField]
    private List<Leg> legs;
    public List<Leg> Legs { get { return this.legs; } }
}
