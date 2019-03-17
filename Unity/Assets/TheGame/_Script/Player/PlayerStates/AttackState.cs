using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    // Time allowed to press the next button
    [SerializeField] 
    private float AllowedTimeBetweenButtons = 2.0f;

    // variable to store te time when the button was pressed
    private float timeLastButtonPressed;

    // The combo set the player is going to execute
    private Queue<Weapon_Attack> combo;
    
    // The combo set the player could execute
    private Queue<Weapon_Attack> auxCombo;

    // The input to execute the combo
    string input;

    WeaponDealDamage weaponDealDamage_;
    
    // Constructor changed to have the combos inserted
    public AttackState(Player player, Queue<Weapon_Attack> comboSetToExecute, Queue<Weapon_Attack> auxComboSet, string inputToAttack) : base(player)
    {
        combo = comboSetToExecute;
        auxCombo = auxComboSet;
        input = inputToAttack;
    }

    public void ComboInputReady()
    {

    }
    public override void Tick()
    {
        //if(!weaponDealDamage_.isAtacking())
        //    player.SetState(new MovementState(player));

        // if the player can continue the combo, we give him the opportunity, if not, he returns to movement state
        if (CanContinueCombo())
        {

            //for the final game = two controllers selected form the controller selection scene
            try
            {
                if (hInput.GetButtonDown(input))
                    performAttack();
            }
            catch { }


            //for developing state of the game
            try
            {
                if (Input.GetButtonDown(input))
                    performAttack();
            }
            catch { }


        }
        else
            player.SetState(new MovementState(player));
        
    }

    // Boolean method to check if the player can continue with the combo
    private bool CanContinueCombo()
    {
        if (Time.time - timeLastButtonPressed < AllowedTimeBetweenButtons)
            return true;
        else
            return false;
    }

    // Method that throws the attack of the respective combo
    private void performAttack()
    {
        player.PlayerManager.ComboSystem.executeComboSet(combo);
        player.PlayerManager.ComboSystem.advanceComboSet(auxCombo);
        timeLastButtonPressed = Time.time;
    }

    public override void OnStateEnter()
    {
        //weaponDealDamage_ = player.GetComponentInChildren<WeaponDealDamage>();
        //player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");


        //weaponDealDamage_.Attack();

        // We execute the first combo odf the queue
        performAttack();
    }

    public override void OnStateExit()
    {
        // When we exit from this state, we reset the combos
        player.PlayerManager.ComboSystem.restartCombo(player.PlayerManager.ComboSet1);
        //player.PlayerManager.ComboSystem.restartCombo(player.PlayerManager.ComboSet2);
    }

}
