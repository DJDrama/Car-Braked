using UnityEngine;
using System.Collections;


public class carController : MonoBehaviour {
    
    public float carSpeed;
    public float maxPos = 2.35f;
    public float minPos = -2.05f;

    Vector3 position;

    public UiManager ui;
    public AudioManager am;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    // Use this for initialization

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
#if UNITY_ANDROID
        currentPlatformAndroid=true;
#else
        currentPlatformAndroid = false;
#endif

        am.carSound.Play();
    }
    void Start () {
       //ui = GetComponent<uiManager>();
        position = transform.position;

        if(currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Windows");
        }
       
	}

    // Update is called once per frame
    void Update() {
        if (currentPlatformAndroid)
        {
            //android specific code
            position= transform.position;            
            position.x = Mathf.Clamp(position.x, minPos, maxPos);
            transform.position = position;

            transform.position = position;
        }
        else
        {//windows specific code
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, minPos, maxPos);

            transform.position = position;
        }

        
            

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.tag == "Enemy Car")
        {
            gameObject.SetActive(false);

            Destroy(gameObject);
            ui.gameOverActivated();
        }


    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }
    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
}
