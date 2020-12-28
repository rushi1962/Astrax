using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score,jumps,level,minAsteroidLength,turret,body;
    public GameObject  mainPanel, gameOverPanel,playerShip,pauseButton,playButton,animationPanel,shipCustomizationPanel,shooter,shootButton;
    public Text scoreText, jumpText, finalText,gameOverText;
    public bool playerShipDestroyed;
    public Transform player;
    public static GameManager gm;
    void Awake()
    {
        if(gm==null)
        {
            gm = GetComponent<GameManager>();
        }
    }
    void Start()
    {
        if(level<=1)
        {
           score= PlayerPrefManager.SetScore();
        }
        score = PlayerPrefManager.GetScore();
        turret = PlayerPrefManager.GetTurret();
        body = PlayerPrefManager.GetBody();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] _asteroids;
        
        if (playerShipDestroyed)
        {
            PlayerDestroyed();
        }
        _asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (_asteroids.Length < minAsteroidLength && jumps>=0)
        {
            PlayerPrefManager.ScoreUpdate(score);
            if(PlayerPrefManager.GetHighScore()<score)
            {
                PlayerPrefManager.SetHighScore(score);
                gameOverText.text = "New HighScore";
            }
            if(level==10)
            {
                StartCoroutine("LoadNextSceneCoroutine", 0);
            }
            else
            {
                StartCoroutine("LoadNextSceneCoroutine", SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
       
    }
    void LateUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
        jumpText.text = "jumps: " + (jumps).ToString();
    }
    void PlayerDestroyed()
    {
        jumps--;
        if(jumps<0)
        {
            finalText.text = "Final Level: " + level + ", Final Score: " + score;

            GameOver();
        }
        else
        {
            StartCoroutine("SpawnNewShip");
            playerShipDestroyed = false;
        }
    }
    void LoadNewScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void GameOver()
    {
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void LoadNextScene()
    {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void PlayAgain()
    {
        LoadNewScene(0);
    }
    public void PauseGame()
    {

        shooter = GameObject.FindGameObjectWithTag("Shooter");
        if(shooter)
        {
            shooter.GetComponent<Shooter>().enabled = false;
        }
        
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        shootButton.SetActive(false);
        playButton.SetActive(true);
        if (shipCustomizationPanel)
        {
            shipCustomizationPanel.SetActive(true);
        }
        
    }
    public void ResumeGame()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        if (shooter)
        {
            shooter.GetComponent<Shooter>().enabled = true;
        }       
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        shootButton.SetActive(true);
        playButton.SetActive(false);
        if(shipCustomizationPanel)
        {
            shipCustomizationPanel.SetActive(false);
        }
        
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    
    public void Scored(int size)
    {
        switch (size)
        {
            case 1:
                {
                    score += Astrax.astrax.asteroidScriptableObject.pointsForAsteroids[0];
                    break;
                }
            case 2:
                {
                    score += Astrax.astrax.asteroidScriptableObject.pointsForAsteroids[1];
                    break;
                }
            case 3:
                {
                    score += Astrax.astrax.asteroidScriptableObject.pointsForAsteroids[2];
                    break;
                }
        }
    }
    IEnumerator SpawnNewShip()
    {
        
        GameObject[] _asteroids;
        Vector3 _newPosition;
        bool _safe=false;
        yield return new WaitForSeconds(0.5f);
        _asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        
        if(_asteroids.Length<=1)
        {
            Instantiate(Astrax.astrax.shipScriptableObject.shipTeleports, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            GameObject newPlayerShip = Instantiate(playerShip, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        else if (_asteroids!=null)
        {
            do
            {
                _newPosition = new Vector3(Random.Range(-16f, 16f), Random.Range(-8f, 8f), 0f);
                foreach (GameObject oneAsteroid in _asteroids)
                {
                    

                    if ((_newPosition - oneAsteroid.transform.position).magnitude < 5.0f)
                    {
                        _safe = false; 
                        break;
                    }
                    _safe = true;
                }
            } while (!_safe);
            Instantiate(Astrax.astrax.shipScriptableObject.shipTeleports, _newPosition, Quaternion.Euler(0, 0, 0));
            GameObject newPlayerShip = Instantiate(playerShip, _newPosition, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        
              
        
    }
    IEnumerator LoadNextSceneCoroutine(int scene)
    {
        yield return new WaitForSeconds(1f);
        LoadNewScene(scene);
    }
    
} 

