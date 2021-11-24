using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float bgSpeed;

    void Update()
    {
        transform.position = transform.position + new Vector3(bgSpeed * Time.deltaTime, 0, 0);

        //if (transform.position.x >= 10)
        //{
        //    transform.position = new Vector3(-10, (float)2.5, 0);
        //}
    }
}