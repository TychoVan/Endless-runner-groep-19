using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public EnemyData Data;

    void Update()
    {
        // Move left
        transform.position = transform.position + new Vector3(-Data.Speed * Time.deltaTime, 0, 0);
    }
}