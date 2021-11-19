using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptableobject/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int      Damage;
    public float    Speed;
}
