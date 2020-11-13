using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneUP : MonoBehaviour
{
    //public GameObject pickupEffect;
    private AudioManager audioManager;
    Coroutine selfDestroy;

    void Start() {
        audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
        selfDestroy = StartCoroutine( DestroyPowerUp() );
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player")) {
            audioManager.Play("pickup");
            StopCoroutine(selfDestroy);
            Pickup(other);
        }
    }

    void Pickup(Collider player) {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Damage damage = player.GetComponent<Damage>();
        damage.IncreaseLife();

        Destroy(gameObject);
    }
    
    IEnumerator DestroyPowerUp() {
        yield return new WaitForSeconds(12);
        Destroy(gameObject);
    }
}
