using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "enemy") {
            Destroy(gameObject);
        }
    }
}
