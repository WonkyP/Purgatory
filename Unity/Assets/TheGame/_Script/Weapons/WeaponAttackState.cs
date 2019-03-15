using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackState : MonoBehaviour
{
    [SerializeField]
    Collider WeaponCollider;

    public void turnColliderOn()
    {
        WeaponCollider.enabled = true;
    }
    public void turnColliderOff()
    {
        WeaponCollider.enabled = true;
    }
}
