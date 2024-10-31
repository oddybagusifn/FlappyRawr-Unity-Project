using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public float xMin, xMax;
    public float yMin, yMax;

    public float smoothTime = 0.3f; // Waktu pergerakan kamera yang halus

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;

        targetPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, xMin, xMax),
            Mathf.Clamp(targetPosition.y, yMin, yMax),
            targetPosition.z
        );

        // Menggunakan Vector3.SmoothDamp() untuk pergerakan kamera yang halus
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}


