using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryExtensions inventoryExtensions;
    public InventoryExtensions InventoryExtensions { get { return this.inventoryExtensions; } }

    // Inventory dictionary
    private Dictionary<string, Dictionary<string, List<InventoryItems>>> inventory = new Dictionary<string, Dictionary<string, List<InventoryItems>>>();
    public Dictionary<string, Dictionary<string, List<InventoryItems>>> Inventory_ { get { return this.inventory; } }

    //------------------------------------------------------------------------------------------------------------

    // Equipment's struct
    [SerializeField]
    private EquipmentItems equipment = new EquipmentItems();
    public EquipmentItems Equipment { get { return this.equipment; } }
    

    // Equipment's dictionary
    private string equipmentKey = "Equipment";
    public string EquipmentKey { get { return this.equipmentKey; } }
    private Dictionary<string, List<InventoryItems>> Equipment_Dictionary = new Dictionary<string, List<InventoryItems>>();

    //---------------------------------------------------------------------------------------------------------

    // Attack's struct
    [SerializeField]
    private AttackItems attacks = new AttackItems();
    public AttackItems Attacks { get { return this.attacks; } }


    // Attacks' dictionary
    private string attacksKey = "Attacks";
    public string AttacksKey { get { return this.attacksKey; } }
    private Dictionary<string, List<InventoryItems>> Attacks_Dictionary = new Dictionary<string, List<InventoryItems>>();

    //---------------------------------------------------------------------------------------------------------

    // Weapon's struct
    [SerializeField]
    private WeaponItems weapons = new WeaponItems();
    public WeaponItems Weapons { get { return this.weapons; } }


    // Weapon's dictionary
    private string weaponsKey = "Weapons";
    public string WeaponsKey { get { return this.weaponsKey; } }
    private Dictionary<string, List<InventoryItems>> Weapons_Dictionary = new Dictionary<string, List<InventoryItems>>();


    private void Start()
    {
        createInventory();

        // To access the inventoryExtensions methods
        inventoryExtensions = GetComponent<InventoryExtensions>();
    }

    // Method that sets up the inventory
    private void createInventory()
    {
        // Setting the keys of the equipment dictionary
        equipment.HelmetsKey = "Helmets";
        equipment.ArmsKey = "Arms";
        equipment.ChestsKey = "Chests";
        equipment.LegsKey = "Legs";

        // Adding the equipment's dictionary and his lists
        inventory.Add(equipmentKey, Equipment_Dictionary);
        Equipment_Dictionary.Add(equipment.HelmetsKey, equipment.Helmets.ConvertAll(x => (InventoryItems)x));
        Equipment_Dictionary.Add(equipment.ArmsKey, equipment.Arms.ConvertAll(x => (InventoryItems)x));
        Equipment_Dictionary.Add(equipment.ChestsKey, equipment.Chests.ConvertAll(x => (InventoryItems)x));
        Equipment_Dictionary.Add(equipment.LegsKey, equipment.Legs.ConvertAll(x => (InventoryItems)x));

        //-----------------------------------------------------------------------------------------------------------

        // Setting the keys of the attacks dictionary
        attacks.WeaponAttacksKey = "WeaponAttacks";
        attacks.SpellAttacksKey = "SpellAttacks";

        // Adding the attack's dictionary and his lists
        inventory.Add(attacksKey, Attacks_Dictionary);
        Attacks_Dictionary.Add(attacks.WeaponAttacksKey, attacks.WeaponAttacks.ConvertAll(x => (InventoryItems)x));
        Attacks_Dictionary.Add(attacks.SpellAttacksKey, attacks.SpellAttacks.ConvertAll(x => (InventoryItems)x));

        //-----------------------------------------------------------------------------------------------------------

        // Setting the keys of the weapons dictionary
        weapons.OneHandedWeaponsKey = "OneHandedWeapons";
        weapons.TwoHandedWeaponsKey = "TwoHandedWeapons";

        // Adding the attack's dictionary and his lists
        inventory.Add(weaponsKey, Weapons_Dictionary);
        Weapons_Dictionary.Add(weapons.OneHandedWeaponsKey, weapons.OneHandedWeapons.ConvertAll(x => (InventoryItems)x));
        Weapons_Dictionary.Add(weapons.TwoHandedWeaponsKey, weapons.TwoHanedWeapons.ConvertAll(x => (InventoryItems)x));

        //---------------------------------------------------------------------------------------------------------------
    }

}
