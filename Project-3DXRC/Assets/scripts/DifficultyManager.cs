using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public Difficulty[] difficulty;
    public int[] Meter;
    private SpawnManager spawnManager;
    private GameManager gameManager;



    void Awake() {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        spawnManager = (SpawnManager)FindObjectOfType(typeof(SpawnManager));
        ChangeDifficulty(difficulty[0].enemyMotorForce, difficulty[0].spawnTime);
    }
    
    void Update() {
        Check(gameManager.explosions);
    }

    void Check(int explosions) {
        for(int i=0; i<Meter.Length-1; i++) {
            if(explosions > Meter[i+1]) {
                continue;
            }
            if(explosions > Meter[i] && explosions < Meter[i+1]) {
                ChangeDifficulty(difficulty[i+1].enemyMotorForce, difficulty[i+1].spawnTime);
            } 
        }
    }

    void ChangeDifficulty( float motorForce, float delay) {
        gameManager.defaultEnemyMotorForce = motorForce;
        spawnManager.spawnDelay = delay;
    }
}
