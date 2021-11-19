using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveData[] Waves;

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
        while (m_WaveTimer > 0)
        {
            yield return new WaitForSeconds(1);
            m_WaveTimer--;
        }
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int _enemies = m_Wave * 3 + 2;
        for (int i = 0; i < Waves[m_Wave].Enemies.Length; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Waves[m_Wave].Enemies[i], transform.position, Quaternion.identity);
        }
        m_Wave++;
        if (m_Wave >= Waves.Length)
        {
            m_Wave = 0;
        }
        m_WaveTimer = 5;

        StartCoroutine(Countdown());
    }
}