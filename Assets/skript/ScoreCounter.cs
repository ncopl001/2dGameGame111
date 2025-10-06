using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int Score = 0;
    private bool firstCollisionIgnored = false;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!firstCollisionIgnored)
        {
            firstCollisionIgnored = true;
            return;
        }
        Score++;
        UpdateScoreUI();

    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Score;
        }
    }

}
