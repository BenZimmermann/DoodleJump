using UnityEngine;
using TMPro;
public class KillArea : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject Player;
    [SerializeField] private TextMeshProUGUI highscoreText;


    private void Awake()
    {
        GameOverCanvas.SetActive(false);
    }
    private void LateUpdate()
    {
        if (mainCamera == null) return;

        Vector3 bottomCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f, mainCamera.nearClipPlane));
        transform.position = new Vector3(bottomCenter.x, bottomCenter.y, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            Player.SetActive(false); // Zerstört den Spieler
            GameOver(); // Optionale Methode
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverCanvas.SetActive(true);

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            int finalScore = scoreManager.HighScore();
            highscoreText.text = "Highscore: " + finalScore.ToString();
        }
        // Zum Beispiel eine Nachricht im Debug-Fenster
        // Oder lade eine Game Over Szene, zeige UI, etc.
    }
}
