using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject StartGround;
    [SerializeField] private GameObject KillArea;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private Camera MainCamera;

    //setzt alle platformen zurück
    //spawnt den spieler neu
    //resettet den score
    public void RestartGame()
    {
        // Alle Plattformen zerstören
        PlatformSpawner[] spawners = FindObjectsOfType<PlatformSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.ResetPlatforms();
        }

        // Spieler zurücksetzen
        if (Player != null)
        {
            Player.transform.position = new Vector3(0, 0, 0); // Setze die Startposition des Spielers
            Player.SetActive(true); // Spieler aktivieren
        }
        if (KillArea != null)
        {
            KillArea.transform.position = new Vector3(0, -15, 0); // Setze die KillArea zurück
        }
        if (MainCamera != null)
        {
            MainCamera.GetComponent<VerticalCameraFollow>().ResetCamera();
            MainCamera.transform.position = new Vector3(0, 0, -10); // Setze die Kamera zurück
        }
        // Score zurücksetzen
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
        
        GameOverCanvas.SetActive(false); // Deaktiviere das Game Over Canvas
    }
}
