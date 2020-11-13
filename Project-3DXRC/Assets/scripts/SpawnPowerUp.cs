using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    // private float angle; 
    // private float spawnCollisionCheckRadius = 1f;
    // create a vector with length 1.0
    [SerializeField]private Vector3 spawnPoint;

    // [SerializeField] private float minLength = -30;
    // [SerializeField] private float maxLength = -90;

    public float length = -1;
    // public float powerUpPickableTime = 12;
    // [SerializeField] private float currentPowerUpPickableTime = 12;
    public GameObject[] powerups;
    private GameObject player;
    private AudioManager audioManager;
    // [SerializeField] private int infiniteLoop = 100;
    public GameObject powerup;

    void Awake() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void Start() {
        player = GameObject.FindWithTag("player");
        // currentPowerUpPickableTime = powerUpPickableTime;
    }
    // void Update() {
    //     currentPowerUpPickableTime -= Time.deltaTime;
    //     if(currentPowerUpPickableTime <= 0) {
    //         currentPowerUpPickableTime = powerUpPickableTime;
    //         Destroy(gameObject);
    //     }
    // }
    // private Vector3 GeneratePoint(float playerPos) {
    //     angle = Random.Range(-Mathf.PI/6,  Mathf.PI/6); 
    //     spawnPoint = new Vector3(Mathf.Sin(angle),0,Mathf.Cos(angle));
    //     length = Random.Range(minLength, maxLength);
    //     spawnPoint *= length;
    //     spawnPoint += player.transform.position;

    //     return spawnPoint;
    // }

    // public float ConvertToRadians(float angle)
    // {
    //     return (Mathf.PI / 180) * angle;
    // }
    public void PowerUpPos() {
        int life = player.GetComponent<Damage>().currentLife;
        // if health is full dont randomly spawn heart
        print(life);
        if(life == 3) {
            powerup = powerups[Random.Range(0, 2)];
        } else {
            powerup = powerups[Random.Range(0, 3)];
        }
        
        // length = Random.Range(minLength, maxLength);
        // print("try");
        // bool foundPosition = false;
        // int count = 0;
        // float playerPos = player.transform.up.y;
        // while(!foundPosition) {
        //     if(count > infiniteLoop) break;
        //     GeneratePoint(playerPos);
        //     print(spawnPoint);
        //     print(Physics.CheckSphere( spawnPoint, spawnCollisionCheckRadius));
        //     if(!Physics.CheckSphere( spawnPoint, spawnCollisionCheckRadius)) {
        //         foundPosition = true;
        //         Debug.Log(spawnPoint);
        //     }
        //     count++;     
        // }
    
        audioManager.Play("powerUp");
        GameObject clone = (GameObject)Instantiate(powerup, player.transform.position + (player.transform.forward * length) , Quaternion.identity);
    }
}
