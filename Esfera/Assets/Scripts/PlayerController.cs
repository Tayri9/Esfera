using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    Vector3 move;
    

    int contadorMoneda = 0;

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
        
    }

    private void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        body.AddForce(move, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)   
    {
        if (col.gameObject.tag == "Coin")
        {
            //Desactivo la moneda
            col.gameObject.SetActive(false);

            //Sumo una moneda
            contadorMoneda++;

            //Muestro el contador de monedas en el Label que se activa al llegar a la meta
            
        }
    }
}
