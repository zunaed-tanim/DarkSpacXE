using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_EvasiveMeneuverTop : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 meneuverTime;
    public Vector2 meneuverWait;
    public Boundary boundary;

    private float currentSpeed;
    private float targetMeneuver;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Evade());
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetMeneuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(meneuverTime.x, meneuverTime.y));
            targetMeneuver = 0;
            yield return new WaitForSeconds(Random.Range(meneuverWait.x, meneuverWait.y));

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newMeneuver = Mathf.MoveTowards(rb.velocity.x, targetMeneuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newMeneuver, 0.0f, currentSpeed);
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
