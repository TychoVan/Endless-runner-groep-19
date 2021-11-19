using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int      CurrentHealth;
    public float    InvincibilityPeriod;

    public void Start()
    {
        if (this.gameObject.GetComponent<PlayerTag>())
        {
            CurrentHealth = this.gameObject.GetComponent<PlayerController>().Data.Health;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
