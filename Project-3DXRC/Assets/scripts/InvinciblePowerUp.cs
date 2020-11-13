using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerUp : MonoBehaviour
{
    // public GameObject pickUpEffect;
    private bool defaultInvincibility;
    public GameObject invincible_ui;
    private GameObject invincible;
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
            StartCoroutine(PickUp(other));
            invincible = Instantiate(invincible_ui, new Vector3(width/2, height - height/5, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("score_ui").transform);  
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

    IEnumerator DestroyPowerUp() {
        yield return new WaitForSeconds(12);
        Destroy(gameObject);
    }
}
