using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas; // Canvas mit Startbutton
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private GameObject GameOverCanvas;
    //[SerializeField] private Rigidbody2D playerRidgidbody;

    private void Start()
    {
        PauseGame();
    }

    public void ReturnStart()
    {
        // Wenn der Startbutton geklickt wird, starte das Spiel
        PauseGame();
    }

    private void PauseGame()
    {
          GameOverCanvas.SetActive(false); // Deaktiviere das Game Over Canvas
        // Deaktiviere die Steuerung am Anfang
        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        //if (playerRidgidbody != null)
        //    playerRidgidbody.velocity = Vector2.zero;
        //    playerRidgidbody.bodyType = RigidbodyType2D.Static;

        // Zeige Startmenü
        if (startCanvas != null)
            startCanvas.SetActive(true);
    }

    public void StartGame()
    {
        RestartManager RestartManager = FindObjectOfType<RestartManager>();
        if (RestartManager != null)
            RestartManager.RestartGame();
        // Steuerung aktivieren
        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        //if (playerRidgidbody != null)
        //    playerRidgidbody.bodyType = RigidbodyType2D.Dynamic;

        // Menü ausblenden
        if (startCanvas != null)
            startCanvas.SetActive(false);

    }
}
