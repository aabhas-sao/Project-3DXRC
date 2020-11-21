using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionEffect;
    // public int cars_destryoed = 0;
    public bool ignoreFirstCollision = true;

    private GameManager gameManager;
    private AudioManager audioManager;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        ignoreFirstCollision = true;
    }
    
    void OnCollisionEnter(Collision collision) {
        if(gameManager.isInvincible) {
            if(ignoreFirstCollision == false) {
                if(collision.collider.tag == "enemy" || collision.collider.tag == "building" || collision.collider.tag == "ground") {
                    ExplodeEnemy();
                }
            }
            
            if(ignoreFirstCollision) {
                ignoreFirstCollision = false;
            }
            if(collision.collider.tag == "player") {
                ExplodeEnemy();
            }
            return;
        }

        if(collision.collider.tag == "enemy" || collision.collider.tag == "building" || collision.collider.tag == "ground") {
            if(ignoreFirstCollision){
                ignoreFirstCollision = false;
                return;
            }
            print("why");
            ExplodeEnemy();
        }
    }
    
    void ExplodeEnemy() {
        audioManager.Play("explosion");
        Destroy(gameObject);
        GameObject clone = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(clone, 2.0f);
        gameManager.explosions++;
        gameManager.ExplosionCount();
    }   
}
