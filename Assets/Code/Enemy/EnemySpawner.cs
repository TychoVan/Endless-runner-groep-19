using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Waves;

    private int m_Wave;
    private float m_WaveTimer;

    private void Start()
    {
        m_Wave = 0;
        m_WaveTimer = 5;

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            int i = Random.Range(0, Waves.Length - 1);
            Instantiate(Waves[i], transform.position, Quaternion.identity);
        }
    }
}