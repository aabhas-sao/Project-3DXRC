using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionEffect;
    public int cars_destryoed = 0;
    private GameManager gameManager;
    

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "enemy" || collision.collider.tag == "building" || collision.collider.tag == "ground") {
            Destroy(gameObject);
            GameObject clone = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(clone, 2.0f);
            gameManager.explosions++;
            gameManager.ExplosionCount();
        }
    }
}
