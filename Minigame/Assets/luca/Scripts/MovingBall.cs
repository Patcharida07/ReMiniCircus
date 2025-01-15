using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 200f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool playerOnBall = false;
    private float playerMovement = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerOnBall)
        {
            // Move the ball in the opposite direction of the player's movement
            Vector2 movement = new Vector2(-playerMovement * moveSpeed, rb.velocity.y);
            rb.velocity = movement;

            // Rotate the ball
            float rotation = playerMovement * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, 0, rotation);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnBall = true;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerMovement = playerController.GetMovementInput();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnBall = false;
            playerMovement = 0f;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}