using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovement Data", menuName = "Scriptableobject/PlayerMovement Data", order = 1)]
public class PlayerMovementData : ScriptableObject
{
    [Tooltip("What input to use according to the old inputsystem.")]
    public string                   InputSelected;

    [Tooltip("The speed which the object will move at.")]
    [Range(0, 10)] public float     Speed;

    [Tooltip("How much health the player will have.")]
    [Range(0, 10)] public int       Health;
}
