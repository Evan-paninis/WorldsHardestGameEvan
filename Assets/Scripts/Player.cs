using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Vector3 startPoint;
    private float vInput;
    private float hInput;
    [SerializeField]public float speed;
    private int Coins = 0;
    [SerializeField] TMP_Text Counter;
    [SerializeField] TMP_Text Congrats;
    [SerializeField] SpriteRenderer finalScreen;
    [SerializeField] SpriteRenderer SpriteRenderer;
    private bool levelCleared = false;
    private int deaths = 0;
    [SerializeField] TMP_Text deathsCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        startPoint = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCleared == false)
        {
            Movements2();
        }
        
        
        //   this.gameObject.transform.position = new Vector3(0, 1, 0);

        //   this.gameObject.transform.eulerAngles += new Vector3(0, 45, 0) * Time.deltaTime;

        //   this.gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    
        
    }

    private void Movements2()
    {
        
        vInput = Input.GetAxisRaw("Vertical"); //0, -1, 1
        hInput = Input.GetAxisRaw("Horizontal");

        Vector3 movementDirection = new Vector3(hInput, vInput, 0).normalized;
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (hInput != 0 || vInput != 0)
        {
            SpriteRenderer.enabled = true;
        }
        else
        {
            SpriteRenderer.enabled = false;
        }


    }
    
    private void Movements()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += new Vector3(1, 0, 0).normalized * 3 * Time.deltaTime;
            
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += new Vector3(-1, 0, 0).normalized * 3 * Time.deltaTime;
            SpriteRenderer.enabled = true;
            

        }
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += new Vector3(0, 1, 0).normalized * 3 * Time.deltaTime;
            SpriteRenderer.enabled = true;
            

        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += new Vector3(0, -1, 0).normalized * 3 * Time.deltaTime;
            SpriteRenderer.enabled = true;
            

        }

        if (!Input.anyKey)
        {
            SpriteRenderer.enabled = false; 
            
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = startPoint;
            Coins = 0;
            Counter.text = "Score: " + Coins;
            deaths += 1;
            deathsCounter.text = "Deaths: " + deaths;
        }

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Coins += 1;
            Counter.text = "Score: " + Coins;  
        }

        if (other.gameObject.CompareTag("Papyrus"))
        {

            if (vInput != 0 || hInput != 0)
            {
                transform.position = startPoint;
                deaths += 1;
                deathsCounter.text = "Deaths: " + deaths;
            }

        }
        if (other.gameObject.tag == "Goal")
        {
            Congrats.enabled = true;
            finalScreen.enabled = true;
            Congrats.text = "Level cleared!";
            levelCleared = true;
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Papyrus"))
        {

            if (vInput != 0 || hInput != 0)
            {
                transform.position = startPoint;
            }

        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Congrats.enabled = true;
            finalScreen.enabled = true;
            Congrats.text = "Level cleared!";
        }
    }
    
    
    
}
