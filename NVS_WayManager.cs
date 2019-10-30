using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_WayManager : MonoBehaviour {

    public GameObject[] structurePrefabs;

    private Transform playerTansform;
    public float spawnNext;
    public Vector3 spawnPosition;
    public float structureLength;
    public float beforeDeletionArea;
    public int structureCount;

    private List<GameObject> activeStructures;

    // Use this for initialization
	void Start ()
    {
        activeStructures = new List<GameObject>();
        playerTansform = GameObject.FindGameObjectWithTag("Player").transform;

        for ( int i = 0; i < structureCount; i++)
        {
            SpawnStructure();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (playerTansform.position.z - beforeDeletionArea> (spawnNext - structureCount * structureLength))
        {
            SpawnStructure();
            DeleteStructure();
        }	
	}

    void SpawnStructure(int prefabIndex = -1)
    {
        GameObject structureObject;
        structureObject = Instantiate(structurePrefabs[0]) as GameObject;
        structureObject.transform.SetParent(transform);

        structureObject.transform.position = Vector3.forward * spawnNext;
        spawnNext += structureLength;
        activeStructures.Add(structureObject);
    } 

    void DeleteStructure()
    {
        Destroy(activeStructures[0]);
        activeStructures.RemoveAt(0);
    }
}