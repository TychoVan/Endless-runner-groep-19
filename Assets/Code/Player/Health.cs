using UnityEngine;
using EZCameraShake;

public class Health : MonoBehaviour
{
    public int      CurrentHealth;

    public void Start()
    {
        // If the assigned object is tagged Player it will set the health at the start health of said object.
        if (this.gameObject.GetComponent<PlayerTag>())
        {
            CurrentHealth = this.gameObject.GetComponent<PlayerController>().Data.Health;
        }

        // Updates the health UI at the start of the game, to showcase the correct number.
        UIManager.Instance.Health.text = string.Format("Health: {0}", CurrentHealth);
    }

    /// <summary>
    /// Subtracts an amount from the current amount of health.
    /// </summary>
    /// <param name="damage">The amount to be subtracted.</param>
    public void TakeDamage(int damage)
    {

        CurrentHealth -= damage;
        // Update the health UI.
        UIManager.Instance.Health.text = string.Format("Health: {0}", CurrentHealth);
        CameraShaker.Instance.ShakeOnce(2f, 4f, .1f, 1f);
        if(CurrentHealth == 0)
        {
            // Start the death sequence.
            GameManager.Instance.Death();
            Destroy(gameObject);
        }
    }
}
