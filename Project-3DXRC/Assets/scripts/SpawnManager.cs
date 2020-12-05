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
    public float spawnDistance = 1f;
    public float minSpawnDistance = 0.1f;
    public float distance;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
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
            distance = Vector3.Distance(player.transform.position, spawnPoint.position);
            if ( distance <= spawnDistance && distance >= minSpawnDistance)
            {
                Vector3 direction = (spawnPoint.transform.position - player.transform.position).normalized;
                Ray ray = new Ray(player.transform.position, direction);
                RaycastHit hit;
                Debug.DrawRay(player.transform.position, direction * 10, Color.yellow);
                if(Physics.Raycast(ray, out hit, spawnDistance)) {
                    if(hit.collider.tag == "ground") {
                        continue;
                    }
                }
                near.Add(spawnPoint);
            }
        }
 
        if (near.Count > 0) {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, near.Count);
            Vector3 dir = -1 * (player.transform.position - near[spawnPointIndex].position).normalized;
            dir.y = 0;
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject instance = (GameObject)Instantiate(enemy, near[spawnPointIndex].position, Quaternion.LookRotation(dir));
        }
    }
}