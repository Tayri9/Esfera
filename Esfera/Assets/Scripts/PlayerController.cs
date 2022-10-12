using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    int totalCoins = 35;//35;
    int coinCounter = 0;
    [SerializeField]
    TextMeshProUGUI labelCoins;

    //tiempo
    float time;
    float totalTime = 50f;//50f
    [SerializeField]
    TextMeshProUGUI labelTime;

    //gameover
    [SerializeField]
    GameObject canvasGameOver;
    [SerializeField]
    TextMeshProUGUI labelGameOver;
    [SerializeField]
    TextMeshProUGUI labelCoinTime;
    [SerializeField]
    TextMeshProUGUI labelButton;

    //canvas monedas y tiempo
    [SerializeField]
    GameObject canvasCoinTime;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        time = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        //contador tiempo
        time = time - 1f * Time.deltaTime;
        labelTime.text = "Time: " + time.ToString("00.0");

        //si el tiempo llega a 0 se termina el juego
        if (time <= 0)
        {
            this.enabled = false;
            labelGameOver.text = "GAME OVER";
            labelButton.text = "Try again";
            labelCoinTime.text = "Coins: " + coinCounter.ToString(); //+ " \nTime: " + time.ToString("00.0");
            canvasCoinTime.SetActive(false);
            canvasGameOver.SetActive(true);
        }

        //contador monedas
        labelCoins.text = "Coins: " + coinCounter.ToString() + "/" + totalCoins.ToString();

        //si se cogen todas las monedas se termina el juego
        if (coinCounter == totalCoins)
        {
            this.enabled = false;
            labelGameOver.text = "VICTORY";
            labelButton.text = "Play again";
            labelCoinTime.text = "Coins: " + coinCounter.ToString() + " \nTime: " + (totalTime - time).ToString("00.0");            
            canvasCoinTime.SetActive(false);
            canvasGameOver.SetActive(true);
        }
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

    //función para el botón
    public void ClickOnButton()
    {
        SceneManager.LoadScene(0);
    }
}
