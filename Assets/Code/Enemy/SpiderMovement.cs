using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(SmoothLerp(3f));
    }

    private IEnumerator SmoothLerp(float time)
    {
        if (transform.position.y <= 0)
        {
            // Go up
            Vector3 startingPos = transform.position;
            Vector3 finalPos = transform.position + (transform.up * 5) + (transform.right * 1);
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        if (transform.position.y >= 4.9)
        {
            // Go down
            Vector3 startingPos = transform.position;
            Vector3 finalPos = transform.position + (transform.up * -5) + (transform.right * 1);
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}