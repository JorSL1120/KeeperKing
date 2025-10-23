using System;
using System.Collections;
using UnityEngine;

public enum Difficulty { Easy, Normal, Hard }

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance ??= FindFirstObjectByType<GameManager>() ?? new GameObject("GameManager").AddComponent<GameManager>();

    public float difficultSpeed = 0f;
    public Difficulty SelectedDifficulty { get; private set; }
    
    [Header("Game UI")]
    public GameUI gameUI;

    private int maxPenalties = 5;
    private int penaltiesToWin = 3;
    private int goalsStriker = 0;
    private int savesKeeper = 0;
    private int penaltiesCount = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        SelectedDifficulty = difficulty;
        Debug.Log("Dificultad: " + difficulty);
    }

    private void OnEnable()
    {
        GameEvents.OnRoundResult += OnRoundResult;
    }
    
    private void OnDisable()
    {
        GameEvents.OnRoundResult -= OnRoundResult;
    }

    private void OnRoundResult(bool saved)
    {
        penaltiesCount++;

        if (saved)
            savesKeeper++;
        else
            goalsStriker++;

        if (savesKeeper >= penaltiesToWin)
        {
            gameUI.ToCanvasWin();
            EndGame();
        }
        else if (goalsStriker >= penaltiesToWin)
        {
            gameUI.ToCanvasLose();
            EndGame();
        }
        else if (penaltiesCount >= maxPenalties)
        {
            if (savesKeeper > goalsStriker)
                gameUI.ToCanvasWin();
            else
                gameUI.ToCanvasLose();
            
            EndGame();
        }
    }

    private void EndGame()
    {
        difficultSpeed = 0;
    }
}