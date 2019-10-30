using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NVS_MenuPanel : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public void StartGame(int sceneIndex)
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("NVS_Hangar");
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
    }

    IEnumerator LoadSceneAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = "Loading " + (int)progress * 100f + "%";

            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
