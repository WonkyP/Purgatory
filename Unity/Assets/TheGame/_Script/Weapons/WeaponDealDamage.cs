using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDealDamage : MonoBehaviour
{
    public Card attack;
    BoxCollider bCollider;

    /// <summary>
    public bool atacking = false;
    /// </summary>

    private void Start()
    {
        bCollider = this.transform.GetComponent<BoxCollider>();
        bCollider.enabled = false;

    }

    public void Attack()
    {
        //attack = TheAttack;
        atacking = true;
        StartCoroutine("EnableAttack");
    }
    IEnumerator EnableAttack()
    {
        yield return new WaitForSeconds(attack.pointOfNoReturn);
        bCollider.enabled = true;
        yield return new WaitForSeconds(attack.endOfAttack);
        bCollider.enabled = false;

        atacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            bCollider.enabled = false;
            other.GetComponent<DummyTakeDamage>().TakeDamage(attack);
        }
    }

    public bool isAtacking()
    {
        return atacking;
    }
}
