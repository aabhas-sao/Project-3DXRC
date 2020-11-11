using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerUp : MonoBehaviour
{
    // public GameObject pickUpEffect;
    private bool defaultInvincibility;
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player")) {
            StartCoroutine( PickUp(other) );
        }
    }

    IEnumerator PickUp(Collider player) {
        //Instantiate(pickUpEffect, transform.position, transform.rotation);

        //the effect of powerup
        GameManager gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        defaultInvincibility = gameManager.isInvincible;
        gameManager.isInvincible = true;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(gameManager.powerupActiveTime);
        
        gameManager.isInvincible = false;

        Destroy(gameObject);
    }
}
