using UnityEngine;
using TMPro; // Only needed if you're displaying score with TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton reference

    public int score = 0;

    [SerializeField] private TMP_Text scoreText; // optional UI element

    private void Awake()
    {
        // Singleton pattern (so it persists and is easily accessed)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
