using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    void Update()
    {
        // Move left
        transform.position = transform.position + new Vector3(2 * Time.deltaTime, 0, 0);
    }
}