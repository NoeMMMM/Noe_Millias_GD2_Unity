using UnityEngine;

public class Goal : MonoBehaviour
{
    public Material normalMaterial;
    public Material bonusMaterial;
    public Material deadMaterial;
    public GameLogic gameLogic;
    
    public enum GoalState
    {
        Normal,
        Bonus,
        Dead
    }
    
    public GoalState currentState = GoalState.Normal;
    
    public const int NORMAL_POINTS = 10;
    public const int BONUS_POINTS = 30;
    public const int DEAD_POINTS = 0;

    void Start()
    {
        SetState(GoalState.Normal);
    }

    public void SetState(GoalState newState)
    {
        currentState = newState;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer == null) return;
        
        switch (currentState)
        {
            case GoalState.Normal:
                if (normalMaterial != null)
                    renderer.material = normalMaterial;
                break;
            case GoalState.Bonus:
                if (bonusMaterial != null)
                    renderer.material = bonusMaterial;
                break;
            case GoalState.Dead:
                if (deadMaterial != null)
                    renderer.material = deadMaterial;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameLogic == null) return;
        
        int pointsToAdd = 0;
        
        switch (currentState)
        {
            case GoalState.Normal:
                pointsToAdd = NORMAL_POINTS;
                break;
            case GoalState.Bonus:
                pointsToAdd = BONUS_POINTS;
                break;
            case GoalState.Dead:
                pointsToAdd = DEAD_POINTS;
                break;
        }
        
        if (pointsToAdd > 0)
        {
            gameLogic.AddScore(pointsToAdd);
        }
    }
}