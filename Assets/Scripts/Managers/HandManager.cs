using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;
    public List<Card> hand = new List<Card>();
    private void Awake()
    {
        Instance = this; 
    }


    public void AddCardToHand(Card data)
    {
        hand.Add(data);
        Debug.Log("Added card to hand: " + data.cardName);
    }
}
