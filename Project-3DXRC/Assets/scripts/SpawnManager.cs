using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class SpawnManager : MonoBehaviour
{
 
    // public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public Transform player;            // The position that that camera will be following.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float spawnDelay = 6f;
    public float spawnDistance = 10;
 
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }
 
    void Spawn()
    {
        // If the player has no health left...
        //if (playerHealth.currentHealth <= 0f)
        // {
        //     // ... exit the function.
        //     return;
        // }
 
        // collect the children that are close.
        List<Transform> near = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform spawnPoint = transform.GetChild(i);
            if (Vector3.Distance(player.transform.position, spawnPoint.position) <= spawnDistance)
            {
                Debug.Log(Vector3.Distance(player.transform.position, spawnPoint.position));
                near.Add(spawnPoint);
            }
        }
 
        if (near.Count > 0) {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, near.Count);
 
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject instance = (GameObject)Instantiate(enemy, near[spawnPointIndex].position, near[spawnPointIndex].rotation);
        }
    }
}