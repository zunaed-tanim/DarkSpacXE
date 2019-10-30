
using UnityEngine;

public class Mover : MonoBehaviour {

    public Rigidbody rb;
    public float speed;

    private bool gameRunTime;
    private float startTime;
    private float runTime;
    private float gameplayTime;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;

        gameRunTime = true;
        startTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (gameRunTime == true)
        {
            gameplayTime += Time.smoothDeltaTime * 10;
        }

        runTime = gameplayTime - startTime;

        do
        {
            speed += speed;
        } while (runTime >= 500 && runTime < 1000 && speed >= -5);
    }

}
