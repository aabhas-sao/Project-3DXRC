using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    [SerializeField]private int life = 3;
    private int currentLife;
    public float invincibleTime = 4;
    public float currentInvincibleTime = 0;
    // private bool isColliding = false;
    [SerializeField]    private GameObject smokeEffect, fireEffect, explosionEffect;    
    private GameManager gameManager;
    public Image[] playerHealth;
    private int iterator;
    
    public bool isInvincible; // checking if invincible powerup is active
    private EnemyController enemyController;
    private AudioManager audioManager;

    void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        currentLife = life;
        DisableAllHealthBars();
        playerHealth[0].enabled = true;
    }

    private void OnCollisionEnter(Collision other) {
        if(gameManager.isInvincible) {
            return;
        }
        
        if(other.collider.CompareTag("enemy")) {
            if(currentInvincibleTime <= 0) {
                ReduceLife();
            }
            currentInvincibleTime = invincibleTime;
        }
    }


    void Update() {
        if(currentInvincibleTime >= 0) {
            currentInvincibleTime -= Time.deltaTime;
            gameManager.currentEnemyMotorForce = 2000f;
        } else {
            gameManager.currentEnemyMotorForce = gameManager.defaultEnemyMotorForce;
        }
    }
    public void ReduceLife() {
        audioManager.Play("minusLife");
        currentLife--;
        HealthVisual();
    }

    public void DisableAllHealthBars() {
        for(int i=0; i < playerHealth.Length; i++) {
            playerHealth[i].enabled = false;
        }
    }

    public void HealthVisual() {
        currentInvincibleTime = invincibleTime;
        if(currentLife == 3) {
            // smokeEffect.SetActive(false);
            // fireEffect.SetActive(false);
            DisableAllHealthBars();
            playerHealth[0].enabled = true;
        }
        if(currentLife == 2) {    
            DisableAllHealthBars();
            playerHealth[1].enabled = true;
            // smokeEffect.SetActive(true);
        } else if(currentLife == 1) {
            // smokeEffect.SetActive(false);
            // fireEffect.SetActive(true);
            DisableAllHealthBars();
            playerHealth[2].enabled = true;
        }
        if(currentLife <=0) {
            // explosionEffect.SetActive(true);
            Debug.Log("player dead");
            audioManager.Play("gameOver");
            GameManager.alive = false;
        }
    }

    public void IncreaseLife() {
        if(currentLife == 3) return;
        currentLife++;
        HealthVisual();
    }
}
