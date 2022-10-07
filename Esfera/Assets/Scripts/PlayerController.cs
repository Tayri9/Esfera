using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float moveZ;

    public float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        moveZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(moveX, moveY, moveZ);
    }
}
