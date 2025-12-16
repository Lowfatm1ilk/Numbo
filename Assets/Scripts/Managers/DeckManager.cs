using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    [Header("Deck")]
    public List<GameObject> deck = new List<GameObject>();

    [Header("Spawn Settings")]
    public Transform spawnPoint;

    void Start()
    {
        ShuffleDeck();
        SpawnDeck();
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);
            GameObject temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void SpawnDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            GameObject card = Instantiate(deck[i], spawnPoint.position, Quaternion.identity);
            card.transform.SetParent(spawnPoint);

            SpriteRenderer sr = card.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = i; 
            }
        }
    }
}


