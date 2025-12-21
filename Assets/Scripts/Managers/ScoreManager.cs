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

        if(card.data.type != CardType.Simple && card.data.effect != null)
        {
            Debug.Log("Played non simple card");
            card.data.effect.Apply(ref score, card, previousCard);
        }

        ReflowPlayedCards();
        CalculateScore();
    }

    void CalculateScore()
    {
        score = 0;
        for (int i = 0; i < playedCards.Count; i++)
        {
            if(playedCards[i].data.type == CardType.Simple)
            {
                score += playedCards[i].currentValue;
                Debug.Log(playedCards[i].currentValue);
            }
        }
        Debug.Log(score);
        CheckScore();
    }

    void CheckScore()
    {
        if(score >= GoalManager.Instance.goal)
        {
            Debug.Log("Win");
        }
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
