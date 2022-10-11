using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    Vector3 move;    
    [SerializeField]
    public float impulse = 9f;
    [SerializeField]
    GameObject prefabParticles;
    int coinCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //movimiento esfera
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        body.AddForce(move, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)   
    {
        if (col.gameObject.tag == "Coin")
        {
            //Particulas
            Instantiate(prefabParticles, col.transform.position, col.transform.rotation);

            //Desactivo la moneda
            col.gameObject.SetActive(false);

            //Sumo una moneda
            coinCounter++;       
            
        }
    }
}
