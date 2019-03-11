using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // A variable to access the combo system
    private ComboSystem comboSystem;
    public ComboSystem ComboSystem { get { return this.comboSystem; } }

    // Player STATS
    [SerializeField]
    private int player_id;
    public int Player_id { get { return this.player_id; } }

    [SerializeField]
    private float stamina;
    public float Stamina { get { return this.stamina; } }

    // A variable to be able to have access to the player
    private Player player;
    public Player Player { get { return this.player; } }

    [SerializeField]
    [Range(1.0f, 20.0f)]
    private int dashDistance;
    public float DashDistance { get { return this.dashDistance; } }

    [SerializeField]
    [Range(1.0f, 20.0f)]
    private int playerSpeed;
    public float PlayerSpeed { get { return this.playerSpeed; } }

    private Health healthScript;
    public Health HealthScript { get { return this.healthScript; } }

    
    // NEW PLAYERMANAGER STORING SYSTEM

    // A default value for the weapon attack empty slots
    private Weapon_Attack defaulWeaponAttack = new Weapon_Attack("Default", -1, "Default");
    public Weapon_Attack DefaulWeaponAttack { get { return this.defaulWeaponAttack; } }

    // Current helmet
    private Helmet currentHelmet;
    public Helmet CurrentHelmet { get { return this.currentHelmet; } set { this.currentHelmet = value; } }

    // Current arm
    private Arm currentArm;
    public Arm CurrentArm { get { return this.currentArm; } set { this.currentArm = value; } }

    // Current chest
    private Chest currentChest;
    public Chest CurrentChest { get { return this.currentChest; } set { this.currentChest = value; } }

    // Current leg
    private Leg currentLeg;
    public Leg CurrentLeg { get { return this.currentLeg; } set { this.currentLeg = value; } }

    // Current OneHandedWeapons
    private OneHandedWeapon currentOneHandedWeapon;
    public OneHandedWeapon CurrentOneHandedWeapon { get { return this.currentOneHandedWeapon; } set { this.currentOneHandedWeapon = value; } }

    // Current TwoHandedWeapons
    private TwoHandedWeapon currentTwoHandedWeapon;
    public TwoHandedWeapon CurrentTwoHandedWeapon { get { return this.currentTwoHandedWeapon; } set { this.currentTwoHandedWeapon = value; } }

    // Current combos
    // A list with the first combo the player can perform
    private List<Weapon_Attack> currentComboSet1 = new List<Weapon_Attack>();
    public List<Weapon_Attack> CurrentComboSet1 { get { return this.currentComboSet1; } }

    // A list with the second combo the player can perform
    private List<Weapon_Attack> currentComboSet2 = new List<Weapon_Attack>();
    public List<Weapon_Attack> CurrentComboSet2 { get { return this.currentComboSet2; } }

    // Queues with the attacks in the game
    // A queue with the first combo the player can perform
    private Queue<Weapon_Attack> comboSet1 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> ComboSet1 { get { return this.comboSet1; } }

    // A queue with the second combo the player can perform
    private Queue<Weapon_Attack> comboSet2 = new Queue<Weapon_Attack>();
    public Queue<Weapon_Attack> ComboSet2 { get { return this.comboSet2; } }


    //------------------------------------------------------
    // TESTING: CAN BE DELETED
    Weapon_Attack atk1_1 = new Weapon_Attack("Attack 1_Combo1", 1, "Sure Strike");
    Weapon_Attack atk2_1 = new Weapon_Attack("Attack 2_Combo1", 2, "Sloppy Stab");
    Weapon_Attack atk3_1 = new Weapon_Attack("Attack 3_Combo1", 3, "Lunge");
    Weapon_Attack atk4_1 = new Weapon_Attack("Attack 2_Combo1", 4, "Fisted Uppercut");
    Weapon_Attack atk5_1 = new Weapon_Attack("Attack 3_Combo1", 5, "Fervent Anger");

    //------------------------------------------------------

    //------------------------------------------------------
    // TESTING: CAN BE DELETED
    Weapon_Attack atk1_2 = new Weapon_Attack("Attack 1_Combo2", 1, "Attack");
    Weapon_Attack atk2_2 = new Weapon_Attack("Attack 2_Combo2", 2, "Attack");
    Weapon_Attack atk3_2 = new Weapon_Attack("Attack 3_Combo3", 3, "Attack");
    //------------------------------------------------------

    private void Start()
    {
        CreatePlayerInventory();

        comboSystem.addAttackToCombo(CurrentComboSet1, atk1_1);
        comboSystem.addAttackToCombo(CurrentComboSet1, atk2_1);
        comboSystem.addAttackToCombo(CurrentComboSet1, atk3_1);
        comboSystem.addAttackToCombo(CurrentComboSet1, atk4_1);
        comboSystem.addAttackToCombo(CurrentComboSet1, atk5_1);

        comboSystem.addAttackToCombo(currentComboSet2, atk1_2);
        comboSystem.addAttackToCombo(currentComboSet2, atk2_2);
        comboSystem.addAttackToCombo(currentComboSet2, atk3_2);

        ComboSystem.createComboQueue(CurrentComboSet1, comboSet1);
        ComboSystem.createComboQueue(CurrentComboSet2, comboSet2);

        healthScript = GetComponent<Health>();
    }

    private void CreatePlayerInventory()
    {
        comboSystem = GetComponent<ComboSystem>();
    }

}
