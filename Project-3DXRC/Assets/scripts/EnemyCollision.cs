using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionEffect;
    public int cars_destryoed = 0;
    private GameManager gameManager;
    private AudioManager audioManager;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    void OnCollisionEnter(Collision collision) {
        if(gameManager.isInvincible) {
            if(collision.collider.tag == "player") {
                ExplodeEnemy();
            }
            return;
        }

        if(collision.collider.tag == "enemy" || collision.collider.tag == "building" || collision.collider.tag == "ground") {
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
