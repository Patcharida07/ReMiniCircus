using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // พื้น Prefab
    public Transform spawnPoint; // จุดเกิดพื้นใหม่
    private float groundWidth = 10f; // ความกว้างของพื้น
    void Update()
    {
        if (spawnPoint.position.x - transform.position.x > groundWidth) // เช็คว่าพื้นควรเพิ่มหรือยัง
        {
            SpawnGround();
        }
    }
    void SpawnGround()
    {
        Instantiate(groundPrefab, spawnPoint.position, Quaternion.identity);
        spawnPoint.position += new Vector3(groundWidth, 0, 0); // ย้ายจุดเกิดพื้นถัดไป
    }
}