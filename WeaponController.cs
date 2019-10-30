using System.Collections.Generic;
using MEC;
using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawnLeft;
    public Transform shotSpawnRight;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
    
    // Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire ()
    {
        Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
        Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
        audioSource.Play();
    }
	
}
