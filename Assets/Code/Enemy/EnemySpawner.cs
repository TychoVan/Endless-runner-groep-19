using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Interval in between spawns.")]
    public GameObject[]     Waves;
    public float            MinSpawnInterval    = 3;
    public float            MaxSpawnInterval    = 15;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    /// <summary>
    /// Spawns a random wave at random intervals (Between MinSpawnInterval and MaxSpawnInterval).
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawner()
    {
        while (true)
        {
            // Wait before spawning.
            yield return new WaitForSeconds(Random.RandomRange(MinSpawnInterval, MaxSpawnInterval));

            // Spawn random wave prefab.
            int i = Random.Range(0, Waves.Length);
            Instantiate(Waves[i], transform.position, Quaternion.identity);
        }
    }
}