using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f; // ความเร็วของพื้น
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ทำให้พื้นเลื่อนไปทางซ้าย
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        // ถ้าพื้นออกจากจอทางซ้าย ให้ลบทิ้ง
        if (transform.position.x < -20f) // ปรับค่า -20f ให้เหมาะกับตำแหน่งในเกม
        {
            Destroy(gameObject);
        }
    }
}
