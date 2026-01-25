using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    [SerializeField] PowerUp powerUpData;
    PowerUpManager powerUpManager;

    void Start()
    {
        powerUpManager = FindFirstObjectByType<PowerUpManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            powerUpManager.ActivatePowerUp(powerUpData);
            Destroy(gameObject);
        }
    }
}