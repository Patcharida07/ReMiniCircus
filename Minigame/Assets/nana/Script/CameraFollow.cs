using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // อ้างอิงถึงตัวละครหรือวัตถุที่ต้องการติดตาม
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void FixedUpdate()
    {
        // คำนวณตำแหน่งใหม่ของกล้อง
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}