
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawnLeft;
    public Transform shotSpawnRight;
    public float fireDelta;

    private float nextFire;
    private GameObject newShot;
    private float myTime;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            //newShot = 
            Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation); //as GameObject;
            Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);

            // create code here that animates the newShot

            //nextFire = nextFire - myTime;

            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }
	
}
