using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Current state of the player
    private State currentState;

    // Player Manager with the current items of the player
    [SerializeField]
    private PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return this.playerManager; } }

    private InputManager inputManager;
    public InputManager InputManager { get { return this.inputManager; } }

    /// <testing_purposes>
    [SerializeField]
    private char player_Id = ' ';
    public char Player_Id { get { return this.player_Id; } set { this.player_Id = value;  } }

    //[SerializeField]
    //private bool joyStickActive = false;
    //public bool JoyStickActive { get { return this.joyStickActive; } set { this.joyStickActive = value; } }


    [SerializeField]
    private bool testingWithKeyBoard = false;
    public bool TestingWithKeyBoard { get { return this.testingWithKeyBoard; } set { this.testingWithKeyBoard = value; } }

    [SerializeField]
    private bool testingWithPs4Controller = false;
    public bool TestingWithPs4Controller { get { return this.testingWithPs4Controller; } set { this.testingWithPs4Controller = value; } }

    [SerializeField]
    private bool testingWithXboxController = false;
    public bool TestingWithXboxController { get { return this.testingWithXboxController; } set { this.testingWithXboxController = value; } }


    /// </testing_purposes>
    /// 
    public int pNumber = 0;

    public string isDS4 = "";


    //public string attackInput1;
    //public string attackInput2;

    Animator anim;
    public Animator Anim
    {
        get
        {
            return this.anim;
        }
    }

    private void Start()
    {
        
        anim = GetComponent<Animator>(); 
        inputManager = GetComponent<InputManager>();
        //attackInput1 = GetComponent<InputManager>().returnAttack_1_InputString();
        //attackInput2 = GetComponent<InputManager>().returnAttack_2_InputString();

        SetState(new MovementState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    // Method to set a new state
    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void setNumber(int i)
    {
        pNumber = i;
    }

    public void setPS4()
    {
        isDS4 = "PS";
    }

    //public string returnAttack_1_InputString()
    //{
    //    return attackInput1;
    //}

    //public string returnAttack_2_InputString()
    //{
    //    return attackInput2;
    //}

    public void GettingHit(float Damage)
    {
        print("Player" + player_Id + " took " + Damage + " Damage");
        PlayerManager.HealthScript.takeDamage(Damage);
    }
}
