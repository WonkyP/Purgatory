using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExtensions : MonoBehaviour
{ 
    private Inventory inv;

    private void Start()
    {
        inv = GetComponent<Inventory>();
    }

    // Method to find an specific inventoryItem
    public InventoryItems FindInventoryItem(string InventoryItem, string TypeofItem, int itemId)
    {
        InventoryItems item = inv.Inventory_[InventoryItem][TypeofItem].Find(x => x.Id == itemId);
        return item;
    }
    //-------------------------------------------------------------------------------------------------

    // Method to find an specific Helmet
    public Helmet FindHelmet(int HelmetId)
    {
        Helmet helmet = (Helmet) FindInventoryItem(inv.EquipmentKey, inv.Equipment.HelmetsKey, HelmetId);
        return helmet;
    }

    // Method to find an specific Arm
    public Arm FindArm(int ArmId)
    {
        Arm arm = (Arm) FindInventoryItem(inv.EquipmentKey, inv.Equipment.ArmsKey, ArmId);
        return arm;
    }

    // Method to find an specific Chest
    public Chest FindChest(int ChestId)
    {
        Chest chest = (Chest) FindInventoryItem(inv.EquipmentKey, inv.Equipment.ChestsKey, ChestId);
        return chest;
    }

    // Method to find an specific Leg
    public Leg FindLeg(int LegId)
    {
        Leg leg = (Leg) FindInventoryItem(inv.EquipmentKey, inv.Equipment.LegsKey, LegId);
        return leg;
    }

    // Method to find an specific Weapon Attack
    public Weapon_Attack FindWeaponAttack(int weaponAttackId)
    {
        Weapon_Attack attack = (Weapon_Attack) FindInventoryItem(inv.AttacksKey, inv.Attacks.WeaponAttacksKey, weaponAttackId);
        return attack;
    }

    // Method to find an specific One Handed Weapon
    public OneHandedWeapon FindOneHandedWeapon(int oneHandedWeaponId)
    {
        OneHandedWeapon oneHandedWeapon = (OneHandedWeapon) FindInventoryItem(inv.WeaponsKey, inv.Weapons.OneHandedWeaponsKey, oneHandedWeaponId);
        return oneHandedWeapon;
    }

    // Method to find an specific Two Handed Weapon
    public TwoHandedWeapon FindTwoHandedWeapon(int twoHandedWeaponId)
    {
        TwoHandedWeapon twoHandedWeapon = (TwoHandedWeapon) FindInventoryItem(inv.WeaponsKey, inv.Weapons.TwoHandedWeaponsKey, twoHandedWeaponId);
        return twoHandedWeapon;
    }
}
