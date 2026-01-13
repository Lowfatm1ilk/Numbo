using UnityEngine;

public enum TurnPhase
{
    GameStart_Draw_Player1,
    GameStart_Draw_Player2,
    PlayerTurn
}

public class TurnManager : MonoBehaviour
{
    public TurnPhase CurrentPhase => phase;

    public static TurnManager Instance;

    public bool player1Turn = true;

    public GameObject player1;
    public GameObject player2;

    public Vector3 player1camera;
    public Vector3 player2camera;
    public GameObject mainCamera;
    private Vector3 targetCameraPosition;
    public float cameraSpeed = 5f;

    public int startingHandSize = 5;
    public int actionsLeft;
    public int actionsPerTurn = 2;

    private TurnPhase phase = TurnPhase.GameStart_Draw_Player1;
    private int cardsDrawnThisPhase = 0;

    void Awake()
    {
        Instance = this;
        actionsLeft = actionsPerTurn;
    }

    void Start()
    {
        targetCameraPosition = player1camera;
        mainCamera.transform.position = targetCameraPosition;
    }

    void Update()
    {
        mainCamera.transform.position = Vector3.MoveTowards(
            mainCamera.transform.position,
            targetCameraPosition,
            cameraSpeed * Time.deltaTime
        );
    }

    public HandManager CurrentHand =>
        player1Turn
            ? player1.GetComponentInChildren<HandManager>()
            : player2.GetComponentInChildren<HandManager>();

    public ScoreManager CurrentScore =>
        player1Turn
            ? player1.GetComponentInChildren<ScoreManager>()
            : player2.GetComponentInChildren<ScoreManager>();

    public void NotifyCardDrawn()
    {
        if (phase == TurnPhase.PlayerTurn)
            return; 

        cardsDrawnThisPhase++;

        if (cardsDrawnThisPhase >= startingHandSize)
        {
            cardsDrawnThisPhase = 0;

            if (phase == TurnPhase.GameStart_Draw_Player1)
            {
                phase = TurnPhase.GameStart_Draw_Player2;
                player1Turn = false;
                UpdateCamera();
                Debug.Log("Player 2 start draw phase");
            }
            else if (phase == TurnPhase.GameStart_Draw_Player2)
            {
                phase = TurnPhase.PlayerTurn;
                player1Turn = true;
                actionsLeft = actionsPerTurn;
                UpdateCamera();
                Debug.Log("Game Start Complete — Player 1 Turn");
            }
        }
    }

    public void SwitchTurn()
    {
        player1Turn = !player1Turn;
        UpdateCamera();
    }

    public void EndTurn()
    {
        SwitchTurn();
        actionsLeft = actionsPerTurn;
    }

    public void UpdateCamera()
    {
        targetCameraPosition = player1Turn ? player1camera : player2camera;
    }

    public void SpendAction()
    {
        actionsLeft--;

        if (actionsLeft <= 0)
        {
            EndTurn();
        }
    }

}
