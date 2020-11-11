using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneUP : MonoBehaviour
{
    //public GameObject pickupEffect;
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player")) {
            Pickup(other);
        }
    }

    void Pickup(Collider player) {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Damage damage = player.GetComponent<Damage>();
        damage.IncreaseLife();

        Destroy(gameObject);
    }
    
}
