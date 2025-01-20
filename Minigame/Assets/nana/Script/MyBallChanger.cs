using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBallChanger : MonoBehaviour
{
    public GameObject[] ballPrefabs; // เก็บ Prefab ของลูกบอลหลายลูก
    private GameObject currentBall; // ลูกบอลปัจจุบัน
    public Transform spawnPoint; // ตำแหน่งเกิดลูกบอลใหม่
    void Start()
    {
        SpawnNewBall();
    }
    public void SpawnNewBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall); // ทำลายลูกบอลเก่า
        }
        int randomIndex = Random.Range(0, ballPrefabs.Length); // สุ่มลูกบอลใหม่
        currentBall = Instantiate(ballPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D other) // เมื่อผู้เล่นถึงจุดเปลี่ยนลูกบอล
    {
        if (other.CompareTag("Player"))
        {
            SpawnNewBall();
        }
    }
}

