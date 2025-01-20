using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // แรงกระโดด
    private Rigidbody2D rb;
    private bool isGrounded = true; // เช็คว่าผู้เล่นอยู่บนพื้นหรือไม่
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // กด Space เพื่อกระโดด
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // ผู้เล่นไม่อยู่บนพื้นหลังจากกระโดด
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // เมื่อผู้เล่นชนพื้น
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // กลับมาอยู่บนพื้นอีกครั้ง
        }
    }
}