using UnityEngine;

public class NVS_PickUpsController : MonoBehaviour {

    public GameObject ConsumableObject;
    public Transform pickUpSpawn;
    public float unloadRate;
    public float delay;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Unload", delay, unloadRate);	
	}
	
	
	void Unload ()
    {
        Instantiate(ConsumableObject, pickUpSpawn.position, pickUpSpawn.rotation);	
	}
}
