using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 10;
    private float maxSpeed = 14;
    private float torqueRange = 10;
    private float spawnPosXRange = 4;
    private float spawnPosY = -2;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque(){
        return Random.Range(-torqueRange, torqueRange);
    }

    private Vector3 RandomPos(){
        return new(Random.Range(-spawnPosXRange, spawnPosXRange), spawnPosY);
    }

    private void OnMouseDown(){
        if(gameManager.isGameActive){
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }
}
