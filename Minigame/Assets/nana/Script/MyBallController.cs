using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBallController : MonoBehaviour
{
 public float speed = 5f; // ความเร็วของลูกบอล
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y); // เพิ่มความเร็วในแนว X
    }
 
}
