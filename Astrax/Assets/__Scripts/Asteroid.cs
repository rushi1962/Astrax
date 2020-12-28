using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    // Start is called before the first frame update
    public int size;
    float _moveSpeed;
    Vector3 _direction;
    Vector3 _rotationVelocity;
    void Start()
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
        _moveSpeed = Random.Range(Astrax.astrax.asteroidScriptableObject.minVelocity, Astrax.astrax.asteroidScriptableObject.maxVelocity);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        _direction = new Vector3(Random.Range(-1.0f,0.5f), Random.Range(-0.5f, 1.0f),0);
        _rotationVelocity = new Vector3(Random.Range(0f, Astrax.astrax.asteroidScriptableObject.maxAngularVelocity), Random.Range(0f, Astrax.astrax.asteroidScriptableObject.maxAngularVelocity), Random.Range(0f, Astrax.astrax.asteroidScriptableObject.maxAngularVelocity));
    }
    void Update()
    {
        
        transform.Rotate(_rotationVelocity*Time.deltaTime);
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position+_direction*(_moveSpeed/size));
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bullet"|| collision.gameObject.tag == "Player")
        {
            Instantiate(Astrax.astrax.asteroidScriptableObject.explosion[size-1],transform.position, Quaternion.Euler(0,0,0));
            if(size!=1)
            {
                for(int i=0;i<Astrax.astrax.numberOfChilds;i++)
                {
                    Astrax.astrax.SpawnAsteroidChild(size - 1, transform.position);
                }
            }
            if(collision.gameObject.tag == "Bullet")
            {
                GameManager.gm.Scored(size);
                if(collision.gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped)
                {
                    AchievementsManager.achievements.luckyShotsCount++;
                }
                
            }
            if(collision.gameObject.tag == "Player")
            {
                Instantiate(Astrax.astrax.shipScriptableObject.shipExplosion, transform.position, Quaternion.Euler(0, 0, 0));
                if (GameManager.gm.jumps==1)
                {
                    //print("Destroyed");

                }
                GameManager.gm.playerShipDestroyed=true;
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }
    static public Asteroid SpawnAsteroid()
    {
        GameObject asteroidPrefab = Instantiate<GameObject>(Astrax.astrax.asteroidScriptableObject.GetAsteroidPrefab());
        Asteroid ast = asteroidPrefab.GetComponent<Asteroid>();
        return ast;
    }
    
}
