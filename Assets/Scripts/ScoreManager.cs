using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreText;


    private float highestY = 0f;

    private void Update()
    {
        if (player == null) return;

        float playerY = player.transform.position.y;

        // Wenn der Spieler höher als zuvor ist, Score updaten
        if (playerY > highestY)
        {
            highestY = playerY;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        int score = Mathf.FloorToInt(highestY) * 20;
        scoreText.text = "Score: " + score.ToString();
    }
    public int HighScore()
    {
        return Mathf.FloorToInt(highestY) * 20;
    }
    public void ResetScore()
    {
        highestY = 0f;
        UpdateScoreDisplay();
    }
}

