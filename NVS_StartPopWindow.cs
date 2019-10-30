using UnityEngine;
using UnityEngine.SceneManagement;


public class NVS_StartPopWindow : MonoBehaviour {

    public static bool StartButtonClicked;
    public static bool StartWindowIsPoped;

    public static bool DrojakIsSelected;
    public static bool MilkyWayIsSelected;
    public static bool XievIsSelected;
        
    public static bool PlayButtonIsSelected;

    public static Scene NVS_Drojak;
    public static Scene NVS_MilkyWay;
    public static Scene NVS_Xiev;
        
    public GameObject StartWindowUI;
    public GameObject SpaceSystemsPanel;


    
    void Start ()
    {
        StartButtonClicked = false;
        StartWindowIsPoped = false;
        DrojakIsSelected = false;
        MilkyWayIsSelected = false;
        XievIsSelected = false;
                        
    }

    public void OnGoDarkClicked()
    {
        while (DrojakIsSelected)
        {
            if (PlayButtonIsSelected)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("NVS_Drojak");
            } break;
            
        } 

        while (MilkyWayIsSelected)
        {
            if (PlayButtonIsSelected)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("NVS_MilkyWay");
            } break;
            
        } 

        while (XievIsSelected)
        {
            if (PlayButtonIsSelected)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("NVS_Xiev");
            } break;
            
        }
        
    }    
          
    public void GoDark()
    {
        PlayButtonIsSelected = true;
    }
        
    public void Drojak()
    {
        DrojakIsSelected = true;
    }

    public void MilkyWay()
    {
        MilkyWayIsSelected = true;
    }

    public void Xiev()
    {
        XievIsSelected = true;
    }


    public void OpenStartWindow()
    {
        StartWindowUI.SetActive(true);
        Time.timeScale = 1f;
        StartWindowIsPoped = true;
    }

    public void OpenSpaceSystemsPanel()
    {
        SpaceSystemsPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void CloseWindow()
    {
        StartWindowUI.SetActive(false);
        Time.timeScale = 1f;
        StartWindowIsPoped = false;
    }
}
