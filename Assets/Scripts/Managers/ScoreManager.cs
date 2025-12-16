using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Transform playedAnchor;
    public float playedCardSpacing = 2f;

    public int score;

    public List<CardFunction> playedCards = new List<CardFunction>();

    void Awake()
    {
        Instance = this;
    }

    public void AddCardToPlay(CardFunction card)
    {
        CardFunction previousCard = null;

        if (playedCards.Count > 0)
            previousCard = playedCards[playedCards.Count - 1];

        playedCards.Add(card);

        if (card.data.effect != null)
        {
            card.data.effect.Apply(ref score, card, previousCard);
            Debug.Log($"Score after {card.data.cardName}: {score}");
        }
        else
        {
            Debug.Log("No effect");
        }

        ReflowPlayedCards();
    }

    void ReflowPlayedCards()
    {
        for (int i = 0; i < playedCards.Count; i++)
        {
            Vector3 pos = new Vector3(i * playedCardSpacing, 0f, 0f);
            playedCards[i].SetPlayPosition(pos);
        }
    }
}
