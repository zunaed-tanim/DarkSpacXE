using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NVS_ConsumablesManager : MonoBehaviour {

    public static int creditsTotal = 0;
    public TextMeshProUGUI creditsBalanceText;
    
    // Use this for initialization
	void Start ()
    {
        //creditsTotal = PlayerPrefs.GetInt("Total Credits", creditsTotal);
        CreditsBalance();
    }

    private void Update()
    {
        
    }

    public void CreditsBalance()
    {

        creditsTotal += NVS_PlayerController.creditsCollected;
        PlayerPrefs.SetInt("Total Credits", creditsTotal);
        creditsBalanceText.text = "DS " + creditsTotal; 
    } 
	
	
}
