using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty { Easy, Normal, Hard }

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance ??= FindFirstObjectByType<GameManager>() ?? new GameObject("GameManager").AddComponent<GameManager>();

    public float difficultSpeed = 0f;
    public Difficulty SelectedDifficulty { get; private set; }
    
    [Header("Game UI")]
    public GameUI gameUI;

    [Header("Penalties UI")]
    [SerializeField] private Image[] penaltiesMarkers;
    public float visibleAlpha = 1f;
    public float fadedAlpha = 0.3f;
    
    [Header("Score Text")]
    [SerializeField] private TextMeshProUGUI keeperScoreText;
    [SerializeField] private TextMeshProUGUI strikerScoreText;

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
            InitializePenaltyMarkers();
            UpdateScoreUI();
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
        if (penaltiesCount < maxPenalties && penaltiesCount < penaltiesMarkers.Length) SetMarkerAlpha(penaltiesMarkers[penaltiesCount], visibleAlpha);
        
        penaltiesCount++;

        if (saved)
            savesKeeper++;
        else
            goalsStriker++;
        
        UpdateScoreUI();

        if (savesKeeper >= penaltiesToWin)
        {
            StartCoroutine(FinishUIWin());
        }
        else if (goalsStriker >= penaltiesToWin)
        {
            StartCoroutine(FinishUILose());
        }
        else if (penaltiesCount >= maxPenalties)
        {
            if (savesKeeper > goalsStriker)
            {
                StartCoroutine(FinishUIWin());
            }
            else
            {
                StartCoroutine(FinishUILose());
            }
        }
    }

    private void EndGame()
    {
        difficultSpeed = 0;
        goalsStriker = 0;
        savesKeeper = 0;
        penaltiesCount = 0;
        
        InitializePenaltyMarkers();
        UpdateScoreUI();
    }

    private void SetMarkerAlpha(Image marker, float alpha)
    {
        if (marker == null) return;
        
        Color color = marker.color;
        
        color.a = alpha;
        marker.color = color;
    }

    private void InitializePenaltyMarkers()
    {
        foreach (Image marker in penaltiesMarkers)
        {
            SetMarkerAlpha(marker, fadedAlpha);
        }
    }

    private void UpdateScoreUI()
    {
        if (keeperScoreText != null) keeperScoreText.text = savesKeeper.ToString();
        if (strikerScoreText != null) strikerScoreText.text = goalsStriker.ToString();
    }

    private IEnumerator FinishUIWin()
    {
        yield return new WaitForSeconds(2f);
        gameUI.ToCanvasWin();
        EndGame();
    }
    
    private IEnumerator FinishUILose()
    {
        yield return new WaitForSeconds(2f);
        gameUI.ToCanvasLose();
        EndGame();
    }
}