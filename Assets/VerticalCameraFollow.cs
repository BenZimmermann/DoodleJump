using UnityEngine;

public class VerticalCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float yOffset = 2f;

    private float highestY;

    void Start()
    {
        if (player != null)
            highestY = transform.position.y; 
    }

    void LateUpdate()
    {
        if (player == null) return;
        if (player.position.y + yOffset > highestY)
        {
            highestY = player.position.y + yOffset;
            transform.position = new Vector3(transform.position.x, highestY, transform.position.z);
        }
       
    }
}
