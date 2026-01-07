using UnityEngine;

public class CardFunction : MonoBehaviour, IClickable
{
    public Card data;
    public int currentValue;
    public bool inHand;
    public bool inPlay;

    [Header("Hover")]
    public float hoverHeight = 0.5f;

    private Vector3 originalLocalPos;
    private int originalSortingOrder;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            originalSortingOrder = sr.sortingOrder;
        currentValue = data.value;
    }

    public void OnClicked()
    {
        Debug.Log("Clicked");
        if (inPlay) return;

        if (inHand)
        {
            MoveToPlay();
            inHand = false;
            inPlay = true;

            HandManager.Instance.RemoveCardFromHand(this);
            return;
        }

        if (!inHand && HandManager.Instance.handCards.Count < HandManager.Instance.maxHandAmount)
        {
            MoveToHand();
            HandManager.Instance.AddCardToHand(this);
            inHand = true;
        }
    }

    public void OnHover()
    {
        if (!inHand) return;

        transform.localPosition = originalLocalPos + Vector3.up * hoverHeight;

        if (sr != null)
            sr.sortingOrder = HandManager.Instance.GetNextSortingOrder();
    }

    public void OnHoverExit()
    {
        if (!inHand) return;

        transform.localPosition = originalLocalPos;

        if (sr != null)
            sr.sortingOrder = originalSortingOrder;
    }

    void MoveToHand()
    {
        transform.SetParent(HandManager.Instance.handAnchor);
    }

    void MoveToPlay()
    {
        transform.SetParent(ScoreManager.Instance.playedAnchor);
        ScoreManager.Instance.AddCardToPlay(this);
    }

    public void SetHandPosition(Vector3 localPos)
    {
        transform.localPosition = localPos;
        originalLocalPos = localPos;
    }

    public void SetPlayPosition(Vector3 localPos)
    {
        transform.localPosition = localPos;
        originalLocalPos = localPos;
    }
}

