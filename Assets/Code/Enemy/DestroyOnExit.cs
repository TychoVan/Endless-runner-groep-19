using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{

    // Temporary script to destroy waves when they fully exit vision. Can be replaced with ObjectPool

    [Tooltip("The number of seconds after which this item will destroy itself.")]
    [SerializeField] private float _lifeTime = 30.0f;

    private float _deathTimer;

    private void Start()
    {
        _deathTimer = 0.0f;
    }

    void Update()
    {
        // Add time to the timer, until it hits the time set in the inspector. Then send the object back to the pool.
        _deathTimer += Time.deltaTime;
        if (_deathTimer >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
