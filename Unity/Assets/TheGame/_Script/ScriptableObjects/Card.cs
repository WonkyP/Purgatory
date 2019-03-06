using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    [Space]
    public int ComboCost; // how much the card cost in a combo
    public float StaminaCost; // how much stamina is drained from using this card

    [Space]
    public Sprite CardSprite;
    public string AnimationTriggerName;

    public float pointOfNoReturn;
    public float endOfAttack;

    public float damage;
}