using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //movimiento
    Rigidbody body;
    Vector3 move;    
    [SerializeField]
    public float impulse = 9f;

    //particulas
    [SerializeField]
    GameObject prefabParticles;

    //monedas
    int coinCounter = 0;
    [SerializeField]
    TextMeshProUGUI labelCoins;

    //tiempo
    float time;
    [SerializeField]
    TextMeshProUGUI labelTime;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        time = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        //contador tiempo
        time = time - 1f * Time.deltaTime;
        labelTime.text = "Time: " + time.ToString("00.0");

        //contador monedas
        labelCoins.text = coinCounter.ToString();
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
