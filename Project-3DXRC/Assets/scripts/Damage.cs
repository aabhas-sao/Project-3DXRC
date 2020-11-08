using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    [SerializeField]private int life = 3;
    private int currentLife;
    private float invincibleTime = 2;
    private float currentInvincibleTime = 0;
    private bool isColliding = false;
    [SerializeField]    private GameObject smokeEffect, fireEffect, explosionEffect;    
    private GameManager gameManager;
    public Image[] playerHealth;
    private int iterator;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        currentLife = life;
        for(int i=0; i < playerHealth.Length; i++) {
            playerHealth[i].enabled = false;
            Debug.Log("disabline" + i);
        }
        iterator = 0;
        playerHealth[0].enabled = true;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("enemy")) {
            if(currentInvincibleTime <= 0) {
                ReduceLife();
            }
            currentInvincibleTime = invincibleTime;
        }
    }


    void Update() {
        if(currentInvincibleTime > 0) {
            currentInvincibleTime -= Time.deltaTime;
        }
    }
    public void ReduceLife() {
        currentLife--;
        
        if(iterator<2) {
            playerHealth[iterator].enabled = false;
            iterator++;
            playerHealth[iterator].enabled = true;
        }

        Debug.Log(currentLife);
        currentInvincibleTime = invincibleTime;
        if(currentLife <=0) {
            Debug.Log("player dead");
            GameManager.alive = false;
        }

        // if(currentLife==2) {
        //     smokeEffect.SetActive(true);
        // } else if(currentLife == 1) {
        //     smokeEffect.SetActive(false);
        // }
    }
}
