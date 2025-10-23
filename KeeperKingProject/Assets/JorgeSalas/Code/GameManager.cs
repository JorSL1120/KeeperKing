using UnityEngine;

public enum Difficulty { Easy, Normal, Hard }
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ??= FindFirstObjectByType<GameManager>() ?? new GameObject("GameManager").AddComponent<GameManager>();
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
    public Difficulty SelectedDifficulty { get; private set; }

    public void SetDifficulty(Difficulty difficulty)
    {
        SelectedDifficulty = difficulty;
        Debug.Log("Dificultad: " + difficulty);
    }
}
