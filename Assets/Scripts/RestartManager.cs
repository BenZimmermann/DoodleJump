using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject StartGround;
    [SerializeField] private GameObject KillArea;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private Camera MainCamera;

    //setzt alle platformen zur�ck
    //spawnt den spieler neu
    //resettet den score
    public void RestartGame()
    {
        // Alle Plattformen zerst�ren
        PlatformSpawner[] spawners = FindObjectsOfType<PlatformSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.ResetPlatforms();
        }

        // Spieler zur�cksetzen
        if (Player != null)
        {
            Player.transform.position = new Vector3(0, 0, 0); // Setze die Startposition des Spielers
            Player.SetActive(true); // Spieler aktivieren
        }
        if (KillArea != null)
        {
            KillArea.transform.position = new Vector3(0, -15, 0); // Setze die KillArea zur�ck
        }
        if (MainCamera != null)
        {
            MainCamera.GetComponent<VerticalCameraFollow>().ResetCamera();
            MainCamera.transform.position = new Vector3(0, 0, -10); // Setze die Kamera zur�ck
        }
        // Score zur�cksetzen
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
        
        GameOverCanvas.SetActive(false); // Deaktiviere das Game Over Canvas
    }
}
