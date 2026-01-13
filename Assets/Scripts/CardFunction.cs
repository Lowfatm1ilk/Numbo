using UnityEngine;

public class CardFunction : MonoBehaviour, IClickable
{
    public Card data;
    public int currentValue;

    public bool inHand;
    public bool inPlay;

    public HandManager ownerHand;
    public ScoreManager ownerScore;

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
        if (inPlay) return;

        if (!inHand && ownerHand == null)
        {
            HandManager hand = TurnManager.Instance.CurrentHand;
            ScoreManager score = TurnManager.Instance.CurrentScore;

            ownerHand = hand;
            ownerScore = score;

            MoveToHand();
            inHand = true;

            bool wasPlayerTurn = TurnManager.Instance.CurrentPhase == TurnPhase.PlayerTurn;

            TurnManager.Instance.NotifyCardDrawn();

            if (wasPlayerTurn)
                TurnManager.Instance.SpendAction();

            return;
        }

        if (inHand)
        {
            if (TurnManager.Instance.CurrentPhase == TurnPhase.PlayerTurn)
            {
                TurnManager.Instance.SpendAction();
                MoveToPlay();
                inHand = false;
                inPlay = true;

                ownerHand.RemoveCardFromHand(this);
            }   
            else
            {
                return;
            }

        }
    }


    public void OnHover()
    {
        if (!inHand) return;

        transform.localPosition = originalLocalPos + Vector3.up * hoverHeight;

        if (sr != null)
            sr.sortingOrder = ownerHand.GetNextSortingOrder();
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
        transform.SetParent(ownerHand.handAnchor);

        if (sr != null)
        {
            sr.sortingLayerName = "Cards";
            sr.sortingOrder = ownerHand.GetNextSortingOrder();
            originalSortingOrder = sr.sortingOrder;
        }

        ownerHand.AddCardToHand(this);
    }


    void MoveToPlay()
    {
        transform.SetParent(ownerScore.playedAnchor);
        ownerScore.AddCardToPlay(this);
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


