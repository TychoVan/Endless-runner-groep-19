using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementData   Data;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float yMovement;
        yMovement = Input.GetAxis(Data.InputSelected) * Data.Speed * Time.deltaTime;

        _rb.velocity = new Vector3(0, yMovement * Data.Speed * 100, 0);

        #region Clamping object between camera bounds.
        // Inspiration taken from https://answers.unity.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html.

        Vector3 sceenBoundary = Camera.main.WorldToViewportPoint(transform.position);
        sceenBoundary.y = Mathf.Clamp(sceenBoundary.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(sceenBoundary);
        #endregion
    }
}
