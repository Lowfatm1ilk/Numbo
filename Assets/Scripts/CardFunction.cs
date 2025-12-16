using UnityEngine;

public class CardFunction : MonoBehaviour, IClickable
{
    public Card data;
    public bool inHand;

    [Header("Hover")]
    public float hoverHeight = 0.5f;

    private Vector3 originalLocalPos;
    private int originalSortingOrder;
    private SpriteRenderer sr;

    void Start()
    {
        originalLocalPos = transform.localPosition;
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            originalSortingOrder = sr.sortingOrder;
        }
    }

    public void OnClicked()
    {
        if (inHand || HandManager.Instance.maxHandAmount == HandManager.Instance.handCards.Count)
        {
            Debug.Log("Card clicked: " + data.cardName);
            return;
        }

        MoveToHand();
        HandManager.Instance.AddCardToHand(data);
        inHand = true;
    }

    public void OnHover()
    {
        if (!inHand) return;

        transform.localPosition = originalLocalPos + Vector3.up * hoverHeight;

        if (sr != null)
        {
            sr.sortingOrder = HandManager.Instance.GetNextSortingOrder();
        }
    }

    public void OnHoverExit()
    {
        if (!inHand) return;

        transform.localPosition = originalLocalPos;

        if (sr != null)
        {
            sr.sortingOrder = originalSortingOrder;
        }
    }

    void MoveToHand()
    {
        Transform anchor = HandManager.Instance.handAnchor;

        transform.SetParent(anchor);
        transform.localPosition = HandManager.Instance.GetNextHandLocalPosition();

        originalLocalPos = transform.localPosition; 

        if (sr != null)
        {
            sr.sortingOrder = HandManager.Instance.GetNextSortingOrder();
            originalSortingOrder = sr.sortingOrder;
        }
    }
}
