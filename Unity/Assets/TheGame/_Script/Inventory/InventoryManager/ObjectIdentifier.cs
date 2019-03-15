using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectIdentifier : MonoBehaviour
{
    // Enums
    public enum TypeOfInventoryItems { Equipment, Attacks, Weapons }
    public enum TypeOfItem { Helmets, Arms, Chests, Legs, WeaponAttacks, SpellAttacks, OneHandedWeapons, TwoHandedWeapons }
    private enum ItemState { Selected, Deselected }

    [SerializeField]
    private TypeOfInventoryItems inventoryItem;
    public TypeOfInventoryItems InventoryItem { get { return this.inventoryItem; } }

    [SerializeField]
    private TypeOfItem item;
    public TypeOfItem Item { get { return this.item; } }

    // To know if the object has been selected or not
    private ItemState itemState = ItemState.Deselected;

    [SerializeField]
    private int objectId;
    public int ObjectId { get { return this.objectId; } }

    // I need it public to let the script know I'm referring to that specific inventory
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private InventoryManager inventoryManager;

    // Items
    string itemType;
    
    Helmet helmet;

    Arm arm;

    Chest chest;

    Leg leg;

    Weapon_Attack attack;

    OneHandedWeapon oneHandedWeapon;

    TwoHandedWeapon twoHandedWeapon;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }

    public void itemSelected()
    {
        itemType = item.ToString();

        if (itemState == ItemState.Deselected)
        {
            EquipmentSelected(itemType);
            AttackSelected(itemType);
            WeaponSelected(itemType);

            itemState = ItemState.Selected;
        }
        else
        {
            EquipmentDeselected(itemType);
            attackDeselected();
            WeaponDeselected(itemType);

            itemState = ItemState.Deselected;
        }

        updateComboSetText();
    }

    private void EquipmentSelected(string itemType)
    {
        if (itemType == TypeOfItem.Helmets.ToString())
        {
            helmet = inventory.InventoryExtensions.FindHelmet(objectId);
            inventoryManager.updatePlayerHelmet(helmet);
        }
        else if (itemType == TypeOfItem.Arms.ToString())
        {
            arm = inventory.InventoryExtensions.FindArm(objectId);
            inventoryManager.updatePlayerArm(arm);
        }
        else if (itemType == TypeOfItem.Chests.ToString())
        {
            chest = inventory.InventoryExtensions.FindChest(objectId);
            inventoryManager.updatePlayerChest(chest);
        }
        else if (itemType == TypeOfItem.Legs.ToString())
        {
            leg = inventory.InventoryExtensions.FindLeg(objectId);
            inventoryManager.updatePlayerLeg(leg);
        }                          
    }

    private void EquipmentDeselected(string itemType)
    {
        if (itemType == TypeOfItem.Helmets.ToString())
            inventoryManager.PlayerHelmetToDefault();
        else if (itemType == TypeOfItem.Arms.ToString())
            inventoryManager.PlayerArmToDefault();
        else if (itemType == TypeOfItem.Chests.ToString())
            inventoryManager.PlayerChestToDefault();
        else if (itemType == TypeOfItem.Legs.ToString())
            inventoryManager.PlayerLegToDefault();
    }

    private void AttackSelected(string itemType)
    {
        if (itemType == TypeOfItem.WeaponAttacks.ToString())
        {
            attack = inventory.InventoryExtensions.FindWeaponAttack(objectId);
            inventoryManager.updatePlayerComboSet(inventoryManager.PlayerManager.CurrentComboSet1, attack);
        }

        inventoryManager.CardNames.Add(attack.Tag);
        GetComponent<Image>().color = Color.magenta;
    }

    private void attackDeselected()
    {
        inventoryManager.PlayerManager.ComboSystem.removeAttackFromCombo(inventoryManager.PlayerManager.CurrentComboSet1, attack);
        inventoryManager.CardNames.Remove(attack.Tag);
        GetComponent<Image>().color = Color.white;
    }

    private void updateComboSetText()
    {
        for (int i = 0; i < inventoryManager.ComboSetNames1.Count; i++)
            inventoryManager.ComboSetNames1[i].text = "";

        for (int i = 0; i < inventoryManager.CardNames.Count; i++)
            inventoryManager.ComboSetNames1[i].text = inventoryManager.CardNames[i];
    }

    private void WeaponSelected(string itemType)
    {
        if (itemType == TypeOfItem.OneHandedWeapons.ToString())
        {
            oneHandedWeapon = inventory.InventoryExtensions.FindOneHandedWeapon(objectId);
            inventoryManager.updatePlayerOneHandedWeapon(oneHandedWeapon);
        }
        else if (itemType == TypeOfItem.TwoHandedWeapons.ToString())
        {
            twoHandedWeapon = inventory.InventoryExtensions.FindTwoHandedWeapon(objectId);
            inventoryManager.updatePlayerTwoHandedWeapon(twoHandedWeapon);
        }
    }

    private void WeaponDeselected(string itemType)
    {
        if (itemType == TypeOfItem.OneHandedWeapons.ToString())
            inventoryManager.PlayerOneHandedWeaponToDefault();
        else if (itemType == TypeOfItem.TwoHandedWeapons.ToString())
            inventoryManager.PlayerTwoHandedWeaponToDefault();
    }

}
