using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovementData   Data;

    private Rigidbody   _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Move according to given speed and input. 
        float yMovement;
        yMovement = Input.GetAxis(Data.InputSelected) * Data.Speed * Time.fixedDeltaTime;
        _rb.velocity = new Vector3(0, yMovement * Data.Speed * 10, 0);

        #region Clamping object between camera bounds.
        // Inspiration taken from https://answers.unity.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html.

        Vector3 sceenBoundary = Camera.main.WorldToViewportPoint(transform.position);
        sceenBoundary.y = Mathf.Clamp(sceenBoundary.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(sceenBoundary);
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the Player Object hits an object tagged Enemy, it will subtract points from it's Health script. If it hits an object tagged Coin it will add 1000 points to its score.
        if (other.gameObject.GetComponent<EnemyTag>())
        {
            this.gameObject.GetComponent<Health>().TakeDamage(other.GetComponent<FlyMovement>().Data.Damage);
        }
        else if (other.gameObject.GetComponent<CoinTag>())
        {
            ScoreManager.Instance.AddToScore(1000);
        }
    }
}
