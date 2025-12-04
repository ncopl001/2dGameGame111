using System.Collections;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private float spawnRate = 2f;           // Initial spawn delay
    [SerializeField] private float minSpawnRate = 0.3f;      // Fastest allowed rate
    [SerializeField] private float difficultyIncrease = 0.05f; // How much faster per spawn

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);

            // Spawn enemy
            int rand = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[rand], transform.position, Quaternion.identity);

            // Increase difficulty (spawn faster)
            spawnRate -= difficultyIncrease;
            spawnRate = Mathf.Clamp(spawnRate, minSpawnRate, 999f);
        }
    }
}

