using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUp : MonoBehaviour
{
    
    private int defaultMultiplierPowerUp;
    // public GameObject pickUpEffect;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player")) {
            StartCoroutine( PickUp( other ) );
        }
    }
    
    IEnumerator PickUp( Collider player ) {
        //Instantiate(pickUpEffect, transform.position, transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        
        
        GameManager gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        defaultMultiplierPowerUp = gameManager.multiplierPowerUp;
        gameManager.multiplierPowerUp = 30;
        
        yield return new WaitForSeconds(gameManager.powerupActiveTime);

        gameManager.multiplierPowerUp = 1;

        Destroy(gameObject);
    }
}
