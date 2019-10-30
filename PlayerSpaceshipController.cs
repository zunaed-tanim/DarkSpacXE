﻿using UnityEngine;
using TMPro;

/*[System.Serializable]
public class NVS_PlayerBoundary
{
    public float xMin, xMax, zMin, zMax;
}*/

public class PlayerSpaceshipController : MonoBehaviour
{

    public Rigidbody rb;
    public int vaultCapacityRedDiamond;
    public int vaultCapacityCredits;
    public float speed;
    public float tilt;
    public float forwardTilt;
    public NVS_PlayerBoundary nvsPlayerboundary;

    public TextMeshProUGUI countPickUp_redDiamond;
    public TextMeshProUGUI countPickUp_Credits;
    private int countRedDiamond;
    private int countCredits = 0;
    public static int redDiamondsCollected;
    public static int creditsCollected;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        creditsCollected = 0;

        redDiamondsCollected = PlayerPrefs.GetInt("RedDiamonds Collected/round", redDiamondsCollected);
        creditsCollected = PlayerPrefs.GetInt("Credits Collected/round", creditsCollected);
    }

    void FixedUpdate()
    {
        //(rb.MovePosition((Vector3.forward * speed) * Time.smoothDeltaTime));
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical") + (speed*Time.smoothDeltaTime)*2;
        float pitch = Input.GetAxis("Pitch");


        Vector3 movement = new Vector3(moveHorizontal, pitch, moveVertical);
        rb.velocity = movement * speed;

        /*rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, nvsPlayerboundary.xMin, nvsPlayerboundary.xMax),
                0,
                Mathf.Clamp(rb.position.z, nvsPlayerboundary.zMin, nvsPlayerboundary.zMax)
            );*/

        rb.rotation = Quaternion.Euler(rb.velocity.y * -forwardTilt, 0, rb.velocity.x * -tilt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp_RedDiamond"))
        {
            other.gameObject.SetActive(false);

            SetCountRedDiamond();
        }
        if (other.gameObject.CompareTag("PickUp_Credits"))
        {
            other.gameObject.SetActive(false);

            SetCountCredits();
        }

    }

    public void SetCountRedDiamond()
    {
        //if ()
        //redDiamondsCollected = PlayerPrefs.SetInt("RedDiamonds Collected/round", redDiamondsCollected);

        countRedDiamond = countRedDiamond + 1;
        countPickUp_redDiamond.text = countRedDiamond.ToString("00");
        if (countRedDiamond > vaultCapacityRedDiamond)
        {
            countPickUp_redDiamond.text = countRedDiamond.ToString("Full");
            redDiamondsCollected += countRedDiamond;
            PlayerPrefs.SetInt("RedDiamonds Collected/round", redDiamondsCollected);
        }
    }

    public void SetCountCredits()
    {
        countCredits++;
        countPickUp_Credits.text = countCredits.ToString("00");
        if (countCredits > vaultCapacityCredits)
        {
            countPickUp_Credits.text = countCredits.ToString("Full");
        }

    }

    public void StoreCollectedCredits()
    {
        while (countCredits >= 1 && NVS_GameController.gameOver == true
            && NVS_GameController.gameRunTime == false)
        {
            creditsCollected += countCredits;
            PlayerPrefs.SetInt("Credits Collected/round", creditsCollected);

        }
    }

}
