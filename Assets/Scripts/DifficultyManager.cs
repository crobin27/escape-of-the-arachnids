using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Singleton instance
    private static DifficultyManager _instance;

    // Difficulty level
    private Difficulty _difficultyLevel;

    // Public property to access the difficulty level
    public Difficulty DifficultyLevel
    {
        get { return _difficultyLevel; }
        set { _difficultyLevel = value; }
    }

    // Static instance property
    public static DifficultyManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        // Enforce singleton pattern
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            _difficultyLevel = Difficulty.Easy;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}