using System.Collections.Generic;
using MEC;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NVS_GameController_MW : MonoBehaviour {

    public GameObject[] Hazards;
    public Vector3 spawnValues;
    public int hazardsCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TextMeshProUGUI survPointsText_MW;
    public TextMeshProUGUI maxSurvPointsText_MW;
    public TextMeshProUGUI countPickUp_redDiamond;
    public TextMeshProUGUI countPickUp_Credits;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    private bool gameOver;
    private bool restart;
    private bool gameRunTime;

    private int survivalPointsMW;
    private int maxSurvivalPointsMW;

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

        maxSurvivalPointsMW = PlayerPrefs.GetInt("Max Survival Points MW", maxSurvivalPointsMW);

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
        survivalPointsMW = (int)gameplayTime;

        //Survival Points Text
        if (survivalPointsMW >= 1000 && survivalPointsMW < 10000)
        {
            survPointsText_MW.text = survivalPointsMW.ToString("0,000") + " SP";
        }
        else if (survivalPointsMW >= 10000)
        {
            maxSurvPointsText_MW.text = survivalPointsMW.ToString("00,000") + " SP";
        }
        else
        {
            survPointsText_MW.text = survivalPointsMW.ToString("000") + " SP";
        }

        //Max Survival Text
        if (survivalPointsMW > maxSurvivalPointsMW)
        {
            maxSurvivalPointsMW = survivalPointsMW;
            PlayerPrefs.SetInt("Max Survival Points MW", maxSurvivalPointsMW);
        }

        if (maxSurvivalPointsMW >= 1000 && maxSurvivalPointsMW < 10000)
        {
            maxSurvPointsText_MW.text = maxSurvivalPointsMW.ToString("0,000") + " SP";
        }
        else if (maxSurvivalPointsMW >= 10000)
        {
            maxSurvPointsText_MW.text = maxSurvivalPointsMW.ToString("00,000") + " SP";
        }
        else
        {
            maxSurvPointsText_MW.text = maxSurvivalPointsMW.ToString("000") + " SP";
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

        if (survivalPointsMW <= 150)
        {
            gameOverText.text = "Disappointing...";
        }
        else if (survivalPointsMW <= 300 && survivalPointsMW > 150)
        {
            gameOverText.text = "S A D. . .";
        }
        else if (survivalPointsMW <= 500 && survivalPointsMW > 300)
        {
            gameOverText.text = "Not Bad . .";
        }
        else if (survivalPointsMW <= 750 && survivalPointsMW > 500)
        {
            gameOverText.text = "That's it?";
        }
        else if (survivalPointsMW <= 1000 && survivalPointsMW > 750)
        {
            gameOverText.text = "Alrighty!";
        }
        else if (survivalPointsMW <= 1300 && survivalPointsMW > 1000)
        {
            gameOverText.text = "Now we talking!";
        }
        else if (survivalPointsMW <= 1600 && survivalPointsMW > 1300)
        {
            gameOverText.text = "Cool!";
        }
        else if (survivalPointsMW <= 2000 && survivalPointsMW > 1600)
        {
            gameOverText.text = "Well done!";
        }
        else if (survivalPointsMW <= 2500 && survivalPointsMW > 2000)
        {
            gameOverText.text = "Way to go!";
        }
        else if (survivalPointsMW <= 3000 && survivalPointsMW > 2500)
        {
            gameOverText.text = "Amazing!";
        }
        else if (survivalPointsMW <= 3600 && survivalPointsMW > 3000)
        {
            gameOverText.text = "Now that's skill!";
        }
        else if (survivalPointsMW <= 4400 && survivalPointsMW > 3600)
        {
            gameOverText.text = "Outstanding!";
        }
        else if (survivalPointsMW <= 5200 && survivalPointsMW > 4400)
        {
            gameOverText.text = "Magnificent!";
        }
        else if (survivalPointsMW <= 6100 && survivalPointsMW > 5200)
        {
            gameOverText.text = "YOU ONE SWIFT BIRD!";
        }
        else if (survivalPointsMW <= 7100 && survivalPointsMW > 6100)
        {
            gameOverText.text = "SHAARPP!!";
        }
        else if (survivalPointsMW <= 7500 && survivalPointsMW > 7100)
        {
            gameOverText.text = "INNSAANE!!";
        }
        else if (survivalPointsMW > 7500)
        {
            gameOverText.text = "TERRIFYING!!!";
        }

    }

}

