using UnityEngine;

public class PlayerController01: MonoBehaviour
{
    [Header("移動參數")]
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 10f; // 跳躍力度

    [Header("地面檢測")]
    public Transform groundCheck; // 用於檢測地面的 Transform
    public float groundCheckRadius = 0.2f; // 地面檢測範圍
    public LayerMask groundLayer; // 地面圖層

    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform originalParent; // 用於存儲原始的父物體

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalParent = transform.parent; // 存儲角色的原始父物體
    }

    void Update()
    {
        // 水平移動
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 檢?是否在地面上
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 跳躍
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    // 翻轉角色面向
    if (moveInput > 0)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    else if (moveInput < 0)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果角色與球體碰撞，建立父子關係
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.parent = collision.transform; // 設置球體為角色的父物體
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 如果角色離開球體，延遲解除父子關係
        if (collision.gameObject.CompareTag("Ball"))
        {
            Invoke("ResetParent", 0.01f);
        }
    }

    private void ResetParent()
    {
        transform.parent = null; // 延遲後解除父子關係
    }

    private void OnDrawGizmosSelected()
    {
        // 可視化地面檢測範圍
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

