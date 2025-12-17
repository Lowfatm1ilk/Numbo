using UnityEngine;
using static System.Random;

public class GoalManager : MonoBehaviour
{
    public int goal;

    public static GoalManager Instance;

    void Awake()
    {
       Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        goal = UnityEngine.Random.Range(50, 251);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
