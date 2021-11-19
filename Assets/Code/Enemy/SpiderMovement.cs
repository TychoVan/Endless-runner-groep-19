using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private float speed;
    public float flySpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SmoothLerp(3f));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, speed, 0);
        // Move left
        transform.position = transform.position + new Vector3(flySpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator SmoothLerp(float time)
    {
        while (true)
        {
            speed = 1;
            yield return new WaitForSeconds(3);

            speed = -1;
            yield return new WaitForSeconds(2);
        }
    }
}