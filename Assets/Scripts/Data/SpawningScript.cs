using System;
using UnityEngine;
using UnityEngine.Splines;

[Serializable]
public class Formation
{
    public float Delay;
    public Traveller EnemyPrefab;
    public SplineContainer Route;
    public int EnemyCount;
}

[CreateAssetMenu(fileName = "SpawningScript", menuName = "Scriptable Objects/SpawningScript")]
public class SpawningScript : ScriptableObject
{
    public Formation[] Waves;
}
