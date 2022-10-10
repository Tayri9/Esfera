using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField]
    public float rotationZ = 100.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotationZ * Time.deltaTime);
    }
}
