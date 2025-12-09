using UnityEngine;

public class CardFunction : MonoBehaviour, IClickable
{
    public Card data;
    public bool inHand;

    public void Start()
    {
        data = this.gameObject.GetComponent<Card>();
    }
    public void OnClicked()
    {
        Debug.Log("Card clicked: " + data.cardName);
        HandManager.Instance.AddCardToHand(data);
    }

}

