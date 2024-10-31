using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    float nilaiRandom;
 
    // Start is called before the first frame update
    void Start()
    {
        nilaiRandom = Random.Range(-2.18f, 1.50f);
        transform.position = new Vector2(transform.position.x, nilaiRandom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
