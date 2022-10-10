using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    Vector3 move;
    public float moveX;
    public float moveY;
    public float moveZ;
    public float moveSpeed = 2.5f;

    [SerializeField]
    public float impulse = 9f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        moveZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        

        //transform.Translate(moveX, moveY, moveZ);  
    }

    private void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        body.AddForce(move, ForceMode.Impulse);
    }
}
