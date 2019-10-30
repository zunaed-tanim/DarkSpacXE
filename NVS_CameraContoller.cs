using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_CameraContoller : MonoBehaviour {

    public GameObject[] players;    //Public variable to store a reference to the player game object
    
    private Vector3 offset;     //Private variable to store the offset distance between the player and camera
    

    private void Awake()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        //while (player.activeInHierarchy)
            //player = GameObject.FindWithTag("Player");


        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        if (players[0].activeInHierarchy)
        {
            offset = transform.position - players[0].transform.position;
        }
        else if (players[1].activeInHierarchy)
        {
            offset = transform.position - players[1].transform.position;
        }
        else if (players[2].activeInHierarchy)
        {
            offset = transform.position - players[2].transform.position;
        }
        else if (players[3].activeInHierarchy)
        {
            offset = transform.position - players[3].transform.position;
        }
        else
        {
            return;
        }

    }


    void FixedUpdate()
    {
        if (players[0].activeSelf)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = players[0].transform.position + offset;
        } 
        else if (players[1].activeSelf)
        {
            transform.position = players[1].transform.position + offset;
        }
        else if (players[2].activeSelf)
        {
            transform.position = players[2].transform.position + offset;
        }
        else if (players[3].activeSelf)
        {
            transform.position = players[3].transform.position + offset;
        }
                
    }

    /*public Transform target;
    public float smoothSpeed = 0.0125f; //Recommended value between 0-1.00
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 
            smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }*/

}
