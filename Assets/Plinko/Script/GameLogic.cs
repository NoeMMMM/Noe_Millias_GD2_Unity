using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public GameObject Canvas;
    public BallSpawner ballSpawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI ballsText;
    public Goal[] goals;
    public EndScreenManager endScreenManager;
    
    public int score;
    public int currentRound = 1;
    public int ballsRemaining;
    public int roundScore;
    public int ballsInPlay = 0;
    
    List<Goal> availableGoalsForBonus = new List<Goal>();
    Goal currentBonusGoal = null;
    
    public const int POINTS_PER_GOAL = 10;
    public const int MAX_ROUNDS = 5;
    public const int STARTING_BALLS = 5;

    void Start()
    {
        score = 0;
        currentRound = 1;
        ballsRemaining = STARTING_BALLS;
        roundScore = 0;
        ballsInPlay = 0;
        
        InitializeGoals();
        SetupRound();
        UpdateUI();
    }

    void InitializeGoals()
    {
        availableGoalsForBonus.Clear();
        
        foreach (Goal goal in goals)
        {
            if (goal != null)
            {
                goal.gameLogic = this;
                goal.SetState(Goal.GoalState.Normal);
                availableGoalsForBonus.Add(goal);
            }
        }
    }

    void SetupRound()
    {
        if (availableGoalsForBonus.Count > 0)
        {
            int randomIndex = Random.Range(0, availableGoalsForBonus.Count);
            currentBonusGoal = availableGoalsForBonus[randomIndex];
            currentBonusGoal.SetState(Goal.GoalState.Bonus);
        }
    }

    void Update()
    {
        if (ballsRemaining <= 0 && ballsInPlay <= 0)
        {
            EndRound();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        roundScore += points;
        UpdateUI();
    }

    public void UseBall()
    {
        ballsRemaining--;
        UpdateUI();
    }

    public void BallDropped()
    {
        ballsInPlay++;
    }

    public void BallFinished()
    {
        ballsInPlay--;
    }

    void EndRound()
    {
        if (currentBonusGoal != null)
        {
            currentBonusGoal.SetState(Goal.GoalState.Dead);
            availableGoalsForBonus.Remove(currentBonusGoal);
            currentBonusGoal = null;
        }
        
        if (currentRound >= MAX_ROUNDS)
        {
            EndGame();
        }
        else
        {
            StartNextRound();
        }
    }

    void StartNextRound()
    {
        currentRound++;
        ballsRemaining = roundScore / 10;
        roundScore = 0;
        
        if (ballsRemaining <= 0)
        {
            EndGame();
            return;
        }
        
        SetupRound();
        UpdateUI();
        
        if (ballSpawner != null)
        {
            ballSpawner.ResetPosition();
            ballSpawner.SetPreviewBallActive(true);
        }
    }

    void EndGame()
    {
        if (ballSpawner != null)
        {
            ballSpawner.SetPreviewBallActive(false);
            ballSpawner.enabled = false;
        }
        
        if (endScreenManager != null)
        {
            endScreenManager.ShowEndScreen(score);
        }
        else if (Canvas != null)
        {
            Canvas.SetActive(true);
        }
        
        enabled = false;
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound + "/" + MAX_ROUNDS;
        }
        
        if (ballsText != null)
        {
            ballsText.text = "Balls: " + ballsRemaining;
        }
    }
}
