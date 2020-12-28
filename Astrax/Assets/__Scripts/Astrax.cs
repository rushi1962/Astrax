using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astrax : MonoBehaviour { 

    public static Astrax astrax;
    public int numberOfChilds = 2;
    public int AsteroidCountAtStart = 3;
    private int i,_minDistanceFromSheep = 5;
    private Transform _ship;
    private Vector3 _pos;
    public AsteroidScriptableObject asteroidScriptableObject;
    public ShipScriptableObjects shipScriptableObject;
    
    void Awake()
    {
        if(astrax==null)
        {
            astrax = gameObject.GetComponent<Astrax>();
        }
        _ship = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        StartCoroutine("SpawnAsteroidsInStart");
    }
    void SpawnAsteroidAtStart(int i)
    {
        if(_ship!=null)
        {
            Asteroid ast = Asteroid.SpawnAsteroid();
            do
            {
                _pos = new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(-8.0f, 8.0f), 0);
            } while ((_pos - _ship.position).magnitude < _minDistanceFromSheep);
            ast.gameObject.transform.position = _pos;
            ast.size = asteroidScriptableObject.initialSize;
        }
       
    }
    public void SpawnAsteroidChild(int size,Vector3 childPos)
    {
        Asteroid ast = Asteroid.SpawnAsteroid();
        
        ast.gameObject.transform.position = childPos;
        ast.size = size;
    }

    IEnumerator SpawnAsteroidsInStart()
    {
        yield return new WaitForSeconds(1.31f);
        if(GameManager.gm.animationPanel)
        {
            GameManager.gm.animationPanel.SetActive(false);
        }
        if(GameManager.gm.level>=1)
        {
            GameManager.gm.minAsteroidLength = 1;
        }
        
        
        for (i = 0; i < AsteroidCountAtStart; i++)
        {
            SpawnAsteroidAtStart(i);
        }
    }
}
