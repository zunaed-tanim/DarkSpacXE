using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_pShipSelExecutor : MonoBehaviour {

    public GameObject[] playerShip;
    public int playerShipSelected;
                
    void Start()
    {
        for (int i = 0; i > transform.childCount; i++)
            playerShip[i] = transform.GetChild(i).gameObject;

        foreach (GameObject ship in playerShip)
            ship.SetActive(false);
            
        if (playerShip[playerShipSelected])
            playerShip[playerShipSelected].SetActive(true);
                
    }

    private void Awake()
    {
        if (NVS_Hangar_playerShipSelector.playerShipIsSelected0 == true)
        {
            LoadPlayerShipOne();
        }
        if (NVS_Hangar_playerShipSelector.playerShipIsSelected1 == true)
        {
            LoadPlayerShipTwo(); 
        }
        if (NVS_Hangar_playerShipSelector.playerShipIsSelected2 == true)
        {
            LoadPlayerShipThree();    
        }
        if (NVS_Hangar_playerShipSelector.playerShipIsSelected3 == true)
        {
            LoadPlayerShipFour();
        }
    }

    
    public void LoadPlayerShipOne()
    {
        playerShip[0].SetActive(true);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(false);
        playerShipSelected = 0;
    }

    public void LoadPlayerShipTwo()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(true);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(false);
        playerShipSelected = 1;
    }

    public void LoadPlayerShipThree()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(true);
        playerShip[3].SetActive(false);
        playerShipSelected = 2;
    }

    public void LoadPlayerShipFour()
    {
        playerShip[0].SetActive(false);
        playerShip[1].SetActive(false);
        playerShip[2].SetActive(false);
        playerShip[3].SetActive(true);
        playerShipSelected = 3;
    }
}
