using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalMoveSpeed = 5f;
    public float jumpForce = 5f;

    private float currentMoveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveHorizontal;
    private Coroutine slowCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = normalMoveSpeed;
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = IsGrounded();

        // Get input
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector2(moveHorizontal * currentMoveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        // Implement your ground checking logic here
        return true; // Placeholder
    }

    public float GetMovementInput()
    {
        return moveHorizontal;
    }

    public void ApplySlow(float slowFactor, float duration)
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        slowCoroutine = StartCoroutine(SlowCoroutine(slowFactor, duration));
    }

    private IEnumerator SlowCoroutine(float slowFactor, float duration)
    {
        currentMoveSpeed = normalMoveSpeed * slowFactor;
        yield return new WaitForSeconds(duration);
        currentMoveSpeed = normalMoveSpeed;
        slowCoroutine = null;
    }
}