using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool player1Turn = true;
    public bool player2Turn = false;

    public GameObject player1;
    public GameObject player2;
    public Vector3 player1camera;
    public Vector3 player2camera;

    public GameObject mainCamera;
    public void Update()
    {
        if (player1Turn)
        {
            mainCamera.transform.position = player1camera;
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else
        {
            mainCamera.transform.position = player2camera;
            player1.SetActive(false);
            player2.SetActive(true);
        }
        
    }
}
