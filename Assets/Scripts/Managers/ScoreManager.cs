using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public List<Card> playedCards = new List<Card>();

    public void AddCard(Card card)
    {
        playedCards.Add(card);
    }


}
