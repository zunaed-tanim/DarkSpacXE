using System.Collections.Generic;
using MEC;
using System.Collections;
using UnityEngine;

public class NVS_LevelManager : MonoBehaviour {

    public GameObject levelOne;
    public GameObject levelTwo;
    private float gameplayTime;
    private bool levelOneDeactived;
    private bool gameRunTime;


    // Use this for initialization
	void Start ()
    {
        gameRunTime = true;

        /*gameplayTime = Time.smoothDeltaTime * 10;
        levelOneDeactived = false;
        levelOne.SetActive(true);
        levelTwo.SetActive(false);*/

        /*if (gameRunTime)
        {
            Timing.RunCoroutine(_SpawnLevelOne());
        }*/

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        /*if (gameplayTime >= 2)
        {
            levelOne.SetActive(false);
            levelOneDeactived = true;
            levelTwo.SetActive(true);
        }
        if (gameplayTime > 10 && levelOneDeactived)
        {
            levelTwo.SetActive(true);
        }*/
	}

    /*IEnumerator<float> _SpawnLevelOne()
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

    }*/

    void DeleteLevelOneObjects()
    {

    }

}
