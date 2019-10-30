using System.Collections.Generic;
using MEC;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NVS_GameController : MonoBehaviour
{
    public GameObject[] Hazards;
    public Vector3 spawnValues;
    public int hazardsCount;    
    public float spawnWait;    
    public float startWait;
    public float waveWait;
        
    public TextMeshProUGUI survPointsText;
    public TextMeshProUGUI maxSurvPointsText;
    public TextMeshProUGUI countPickUp_redDiamond;
    public TextMeshProUGUI countPickUp_Credits;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    //private NVS_PlayerController nvs_PlayerController;
    public static bool gameOver;
    private bool restart;
    public static bool gameRunTime;
        
    private int survivalPoints;
    private int maxSurvivalPoints;
    private int pickedUpRedDiamonds;

    private float startTime;
    private float runTime;
    private float gameplayTime;
                
    // Use this for initialization
    void Start()
    {
        gameRunTime = true;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
                                
        maxSurvivalPoints = PlayerPrefs.GetInt("Max Survival Points", maxSurvivalPoints);
        

        if (gameRunTime)
        {
            Timing.RunCoroutine(_SpawnWaves());
        }
                
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunTime == true)
        {
            gameplayTime += Time.smoothDeltaTime * 10;
            
        }
        
        //runTime = gameplayTime;
        survivalPoints = (int)gameplayTime;
                
        //Survival Points Text
        if (survivalPoints >= 1000 && survivalPoints < 10000)
        {
            survPointsText.text = survivalPoints.ToString("0,000") + " SP";
        }
        else if (survivalPoints >= 10000)
        {
            maxSurvPointsText.text = survivalPoints.ToString("00,000") + " SP";
        }
        else
        {
            survPointsText.text = survivalPoints.ToString("000") + " SP";
        }

        //Max Survival Text
        if (survivalPoints > maxSurvivalPoints)
        {
            maxSurvivalPoints = survivalPoints;
            PlayerPrefs.SetInt("Max Survival Points", maxSurvivalPoints);
        }

        if (maxSurvivalPoints >= 1000 && maxSurvivalPoints < 10000)
        {
            maxSurvPointsText.text = maxSurvivalPoints.ToString("0,000") + " SP";
        }
        else if (maxSurvivalPoints >= 10000)
        {
            maxSurvPointsText.text = maxSurvivalPoints.ToString("00,000") + " SP";
        }
        else
        {
            maxSurvPointsText.text = maxSurvivalPoints.ToString("000") + " SP";
        }

        
                
        //restart text        
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    
    IEnumerator<float> _SpawnWaves()
    {
        yield return Timing.WaitForSeconds(startWait);

        while (true && gameRunTime)
        {
            for (int i = 0; i <= hazardsCount; i++)
            {
                GameObject Hazard = Hazards[Random.Range(0, Hazards.Length)];
                Vector3 spawnPosition = new Vector3
                (Random.Range(-spawnValues.x, spawnValues.x), 
                spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(Hazard, spawnPosition, spawnRotation);

                yield return Timing.WaitForSeconds(spawnWait);
            }
            yield return Timing.WaitForSeconds(waveWait);
                                    
            if (gameOver)
            {
                restartText.text = "Press 'R' and try again!";
                restart = true;
                break;
            }
                        
        }
    }
   
        
    public void GameOver()
    {
        gameOver = true;

        if (gameOver)
        {
            gameRunTime = false;
        }

        if (survivalPoints <= 200)
        {
            gameOverText.text = "Disappointing...";
        }
        else if (survivalPoints <= 400 && survivalPoints > 200)
        {
            gameOverText.text = "S A D. . .";
        }
        else if (survivalPoints <= 600 && survivalPoints > 400)
        {
            gameOverText.text = "Not Bad . .";
        }
        else if (survivalPoints <= 800 && survivalPoints > 600)
        {
            gameOverText.text = "That's it?";
        }
        else if (survivalPoints <= 1000 && survivalPoints > 800)
        {
            gameOverText.text = "Alrighty!";
        }
        else if (survivalPoints <= 1250 && survivalPoints > 1000)
        {
            gameOverText.text = "Now we talking!";
        }
        else if (survivalPoints <= 1500 && survivalPoints > 1250)
        {
            gameOverText.text = "Cool!";
        }
        else if (survivalPoints <= 1750 && survivalPoints > 1500)
        {
            gameOverText.text = "Well done!";
        }
        else if (survivalPoints <= 2000 && survivalPoints > 1750)
        {
            gameOverText.text = "Way to go!";
        }
        else if (survivalPoints <= 2500 && survivalPoints > 2000)
        {
            gameOverText.text = "Amazing!";
        }
        else if (survivalPoints <= 3000 && survivalPoints > 2500)
        {
            gameOverText.text = "Now that's skill!";
        }
        else if (survivalPoints <= 4000 && survivalPoints > 3000)
        {
            gameOverText.text = "Outstanding!";
        }
        else if (survivalPoints <= 5000 && survivalPoints > 4000)
        {
            gameOverText.text = "Magnificent!";
        }
        else if (survivalPoints <= 6500 && survivalPoints > 5000)
        {
            gameOverText.text = "YOU SWIFT BIRD!";
        }
        else if (survivalPoints <= 8000 && survivalPoints > 6500)
        {
            gameOverText.text = "SHAARPP!";
        }
        else if (survivalPoints <= 10000 && survivalPoints > 8000)
        {
            gameOverText.text = "INNSAANE!!";
        }
        else if (survivalPoints > 10000)
        {
            gameOverText.text = "TERRIFYING!!!";
        }
        
    }

}