using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public Transform handAnchor;
    public float cardSpacing = 1.5f;
    public int maxHandAmount = 5;

    private int sortingIndex = 100;
    public List<CardFunction> handCards = new List<CardFunction>();

    public void AddCardToHand(CardFunction card)
    {
        handCards.Add(card);
        ReflowHand();
    }

    public void RemoveCardFromHand(CardFunction card)
    {
        handCards.Remove(card);
        ReflowHand();
    }

    void ReflowHand()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            Vector3 pos = new Vector3(i * cardSpacing, 0f, 0f);
            handCards[i].SetHandPosition(pos);
        }
    }

    public int GetNextSortingOrder()
    {
        return sortingIndex++;
    }
}
