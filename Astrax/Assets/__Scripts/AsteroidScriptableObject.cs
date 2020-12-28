using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="New Asteroid",menuName="Asteroid")]
public class AsteroidScriptableObject : ScriptableObject
{
    public float minVelocity;
    public float maxVelocity;
    public float maxAngularVelocity;
    public int initialSize;
    public float asteroidScale;
    public int numberOfSmallerAsteroids;
    public int[] pointsForAsteroids;
    public GameObject[] asteroidsPrefabs;
    public GameObject[] explosion;
    public GameObject GetAsteroidPrefab()
    {
        int index = Random.Range(0,asteroidsPrefabs.Length-1);
        return asteroidsPrefabs[index];
    }
}
