using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "PlayerMovement Data", menuName = "Create PlayerMovement Data", order = 0)]
public class PlayerMovementData : ScriptableObject
{
    [Tooltip("What input to use according to the old inputsystem.")]
    public string                   InputSelected;

    [Tooltip("The speed which the object will move at.")]
    [Range(0, 10)] public float     Speed;
}
