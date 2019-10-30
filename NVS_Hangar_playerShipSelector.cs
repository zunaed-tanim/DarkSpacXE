using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_Hangar_playerShipSelector : MonoBehaviour {

    public GameObject[] playerShip;
    public int playerShipSelected;
    public static bool playerShipIsSelected0;
    public static bool playerShipIsSelected1;
    public static bool playerShipIsSelected2;
    public static bool playerShipIsSelected3;

    // Use this for initialization
    void Start ()
    {      
        playerShipSelected = PlayerPrefs.GetInt("playerShipSelected");
                
        foreach (GameObject ship in playerShip)
            ship.SetActive(false);

        if (playerShip[playerShipSelected])
            playerShip[playerShipSelected].SetActive(true);

        playerShipIsSelected0 = false;
        playerShipIsSelected1 = false;
        playerShipIsSelected2 = false;
        playerShipIsSelected3 = false;

        /*playerShip[0].SetActive(true);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(false);*/
                
    }
	
	public void LoadPlayerShipOne()
    {
        playerShip[0].SetActive(true);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(false);

        playerShipSelected = 0;
        playerShipIsSelected0 = true;
    }

    public void LoadPlayerShipTwo()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(true);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(false);

        playerShipSelected = 1;
        playerShipIsSelected1 = true;
    }

    public void LoadPlayerShipThree()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(true);
        playerShip[3].SetActive(false);

        playerShipSelected = 2;
        playerShipIsSelected2 = true;
    }

    public void LoadPlayerShipFour()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(true);

        playerShipSelected = 3;
        playerShipIsSelected3 = true;
    }

    public void PlayerShipConfirmed()
    {
        PlayerPrefs.SetInt("playerShipSelected", playerShipSelected);
    }
    
}
