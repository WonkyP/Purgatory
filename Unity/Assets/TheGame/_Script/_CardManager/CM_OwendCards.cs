using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_OwendCards : MonoBehaviour
{
    public List<Card> P1Cards;
    public List<Card> P2Cards;

    public List<Card> StarterDeck;

    public void GiveStarterDeck()
    {
        P1Cards = StarterDeck;
        P2Cards = StarterDeck;
    }
    private void Start()
    {
        GiveStarterDeck();
        //print("Yo here's your starter deck!");
    }
}