using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;
    public int winningScore = 50;

    public Text scoreText;
    public Text instructionsText;

    private bool gameOver = false;

    void Awake()
    {
        // Singleton pattern so other scripts can access this GameManager easily
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        instructionsText.text = "Press 'P' to Pause | Press 'R' to Restart";
        Time.timeScale = 1f; // Ensure the game is unpaused at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle pause
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        }
    }

    public void AddScore(int playerNumber, int amount)
    {
        if (gameOver) return;

        if (playerNumber == 1)
            player1Score += amount;
        else if (playerNumber == 2)
            player2Score += amount;

        UpdateScoreUI();
        CheckWin();
    }

    void CheckWin()
    {
        if (player1Score >= winningScore)
        {
            EndGame("Snake 1 Wins!");
        }
        else if (player2Score >= winningScore)
        {
            EndGame("Snake 2 Wins!");
        }
    }

    void EndGame(string winnerMessage)
    {
        gameOver = true;
        Time.timeScale = 0f; // Pause the game
        instructionsText.text = winnerMessage + " Press 'R' to Restart.";
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Snake 1: {player1Score}   Snake 2: {player2Score}";
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}

