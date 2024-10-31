using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeRolling : MonoBehaviour
{
    public float kecepatanGerak = 2f; // Kecepatan pergerakan objek ke kiri

    void Update()
    {
        // Menggerakkan objek ke kiri
        transform.Translate(Vector3.left * kecepatanGerak * Time.deltaTime);
    }
}


