using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{

    // Temporary script to destroy waves when they fully exit vision. Can be replaced with ObjectPool

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
