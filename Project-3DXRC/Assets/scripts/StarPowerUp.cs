using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUp : MonoBehaviour
{
    
    private int defaultMultiplierPowerUp;
    // public GameObject pickUpEffect;
    public GameObject star_ui;
    private GameObject power_up_ui;
    private float width = Screen.width;
    private float height = Screen.height;
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
            StartCoroutine( PickUp( other ) );
            power_up_ui = Instantiate(star_ui, new Vector3(width/2, height - height/5, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("score_ui").transform);
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
    IEnumerator DestroyPowerUp() {
        yield return new WaitForSeconds(12);
        Destroy(gameObject);
    }
}
