using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionEffect;
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "enemy") {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
