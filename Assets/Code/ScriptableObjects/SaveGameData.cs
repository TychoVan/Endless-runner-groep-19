using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "SaveGame", menuName = "Scriptableobject/SaveGame", order = 0)]
public class SaveGameData : ScriptableObject
{
    public float HighScore;
}
