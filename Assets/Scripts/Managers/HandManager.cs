using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    public Transform handAnchor;
    public float cardSpacing = 1.5f;

    public List<Card> handCards = new List<Card>();

    private int sortingIndex = 100;

    public int maxHandAmount;

    void Awake()
    {
        Instance = this;
    }

    public Vector3 GetNextHandLocalPosition()
    {
        return new Vector3(handCards.Count * cardSpacing, 0f, 0f);
    }

    public void AddCardToHand(Card card)
    {
        handCards.Add(card);
    }

    public int GetNextSortingOrder()
    {
        return sortingIndex++;
    }
}
