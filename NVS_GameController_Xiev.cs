using System.Collections.Generic;
using MEC;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NVS_GameController_Xiev : MonoBehaviour {

    public GameObject[] Hazards;
    public Vector3 spawnValues;
    public int hazardsCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TextMeshProUGUI survPointsText_Xiev;
    public TextMeshProUGUI maxSurvPointsText_Xiev;
    public TextMeshProUGUI countPickUp_redDiamond;
    public TextMeshProUGUI countPickUp_Credits;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    private bool gameOver;
    private bool restart;
    private bool gameRunTime;

    private int survivalPoints_Xiev;
    private int maxSurvivalPoints_Xiev;

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

        maxSurvivalPoints_Xiev = PlayerPrefs.GetInt("Max Survival Points Xiev", maxSurvivalPoints_Xiev);

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
        survivalPoints_Xiev = (int)gameplayTime;

        //Survival Points Text
        if (survivalPoints_Xiev >= 1000 && survivalPoints_Xiev < 10000)
        {
            survPointsText_Xiev.text = survivalPoints_Xiev.ToString("0,000") + " SP";
        }
        else if (survivalPoints_Xiev >= 10000)
        {
            maxSurvPointsText_Xiev.text = survivalPoints_Xiev.ToString("00,000") + " SP";
        }
        else
        {
            survPointsText_Xiev.text = survivalPoints_Xiev.ToString("000") + " SP";
        }

        //Max Survival Text
        if (survivalPoints_Xiev > maxSurvivalPoints_Xiev)
        {
            maxSurvivalPoints_Xiev = survivalPoints_Xiev;
            PlayerPrefs.SetInt("Max Survival Points Xiev", maxSurvivalPoints_Xiev);
        }

        if (maxSurvivalPoints_Xiev >= 1000 && maxSurvivalPoints_Xiev < 10000)
        {
            maxSurvPointsText_Xiev.text = maxSurvivalPoints_Xiev.ToString("0,000") + " SP";
        }
        else if (maxSurvivalPoints_Xiev >= 10000)
        {
            maxSurvPointsText_Xiev.text = maxSurvivalPoints_Xiev.ToString("00,000") + " SP";
        }
        else
        {
            maxSurvPointsText_Xiev.text = maxSurvivalPoints_Xiev.ToString("000") + " SP";
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

        if (survivalPoints_Xiev <= 100)
        {
            gameOverText.text = "Disappointing...";
        }
        else if (survivalPoints_Xiev <= 200 && survivalPoints_Xiev > 100)
        {
            gameOverText.text = "S A D. . .";
        }
        else if (survivalPoints_Xiev <= 300 && survivalPoints_Xiev > 200)
        {
            gameOverText.text = "Not Bad . .";
        }
        else if (survivalPoints_Xiev <= 400 && survivalPoints_Xiev > 300)
        {
            gameOverText.text = "That's it?";
        }
        else if (survivalPoints_Xiev <= 500 && survivalPoints_Xiev > 400)
        {
            gameOverText.text = "Alrighty!";
        }
        else if (survivalPoints_Xiev <= 750 && survivalPoints_Xiev > 500)
        {
            gameOverText.text = "Now we talking!";
        }
        else if (survivalPoints_Xiev <= 1000 && survivalPoints_Xiev > 750)
        {
            gameOverText.text = "Cool!";
        }
        else if (survivalPoints_Xiev <= 1200 && survivalPoints_Xiev > 1000)
        {
            gameOverText.text = "Well done!";
        }
        else if (survivalPoints_Xiev <= 1500 && survivalPoints_Xiev > 1200)
        {
            gameOverText.text = "Way to go!";
        }
        else if (survivalPoints_Xiev <= 1750 && survivalPoints_Xiev > 1500)
        {
            gameOverText.text = "Amazing!";
        }
        else if (survivalPoints_Xiev <= 2000 && survivalPoints_Xiev > 1750)
        {
            gameOverText.text = "That's some Agility!";
        }
        else if (survivalPoints_Xiev <= 2250 && survivalPoints_Xiev > 2000)
        {
            gameOverText.text = "Outstanding!";
        }
        else if (survivalPoints_Xiev <= 2500 && survivalPoints_Xiev > 2250)
        {
            gameOverText.text = "Magnificent!";
        }
        else if (survivalPoints_Xiev <= 3000 && survivalPoints_Xiev > 2500)
        {
            gameOverText.text = "YOU ONE SWIFT BIRD!";
        }
        else if (survivalPoints_Xiev <= 4000 && survivalPoints_Xiev > 3000)
        {
            gameOverText.text = "SHAARPP!!";
        }
        else if (survivalPoints_Xiev <= 5000 && survivalPoints_Xiev > 4000)
        {
            gameOverText.text = "INNSAANE!!";
        }
        else if (survivalPoints_Xiev > 5000)
        {
            gameOverText.text = "TERRIFYING!!!";
        }

    }

}

