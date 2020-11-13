using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    private float angle; 
    // private float spawnCollisionCheckRadius = 1f;
    // create a vector with length 1.0
    Vector3 spawnPoint;
    [SerializeField] private float minLength = -30;
    [SerializeField] private float maxLength = -90;
    [SerializeField] private float length = -5;
    [SerializeField] private float powerUpPickableTime = 7;
    public GameObject[] powerups;
    private GameObject player;
    private AudioManager audioManager;
    // [SerializeField] private int infiniteLoop = 100;
    
    void Awake() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void Start() {
        player = GameObject.FindWithTag("player");
    }

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
    public IEnumerator PowerUpPos() {

        GameObject powerup = powerups[Random.Range(0, 2)];
        length = Random.Range(minLength, maxLength);
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
        yield return new WaitForSeconds(powerUpPickableTime);
        Destroy(clone);
    }
}
