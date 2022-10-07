using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    public float rotationZ = 0.0f * Time.deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
