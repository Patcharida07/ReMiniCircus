using UnityEngine;

public class RingOfFire : MonoBehaviour
{
    public float slowFactor = 0.5f;
    public float slowDuration = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplySlowEffect(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplySlowEffect(other.gameObject);
        }
    }

    private void ApplySlowEffect(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ApplySlow(slowFactor, slowDuration);
        }
    }
}
