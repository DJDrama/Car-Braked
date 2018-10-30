using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    public float maxPos = 2.2f;
    public float minPos = -2.0f;
    public float delayTimer = 0.01f;

    float timer;

    // Use this for initialization
    void Start () {
        timer = delayTimer;       
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(minPos, maxPos), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 3);

            Instantiate(cars[carNo], carPos, transform.rotation);//add random car.
            timer = delayTimer;
        }        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
        }
    }
}
