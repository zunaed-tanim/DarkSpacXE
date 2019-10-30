using UnityEngine;
using TMPro;

[System.Serializable]
public class NVS_PlayerBoundary
{
    public float xMin, xMax, zMin, zMax;
}

public class NVS_PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public int vaultCapacityRedDiamond;
    public int vaultCapacityCredits;
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    Transform playerTransform;
    //public float tilt;
    public NVS_PlayerBoundary nvsPlayerboundary;

    public TextMeshProUGUI countPickUp_redDiamond;
    public TextMeshProUGUI countPickUp_Credits;
    private int countRedDiamond;
    private int countCredits = 0;
    public static int redDiamondsCollected;
    public static int creditsCollected;

    private void Awake()
    {
        playerTransform = transform;
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        creditsCollected = 0;
                
        redDiamondsCollected = PlayerPrefs.GetInt("RedDiamonds Collected/round", redDiamondsCollected);
        creditsCollected = PlayerPrefs.GetInt("Credits Collected/round", creditsCollected);
	}
        
    void FixedUpdate()
    {
        Vector3 movement = new Vector3();
        rb.velocity = movement * speed; 

        Turn();
        Thrust();

        /*rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, nvsPlayerboundary.xMin, nvsPlayerboundary.xMax),
                rb.position.y,
                rb.position.z , nvsPlayerboundary.zMin, nvsPlayerboundary.zMax
            );*/        
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.smoothDeltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.smoothDeltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.smoothDeltaTime * Input.GetAxis("Roll");

        //playerTransform.Rotate(-pitch, yaw, roll);
        playerTransform.rotation = Quaternion.Euler(rb.velocity.z * -pitch, rb.velocity.y * yaw, rb.velocity.x * roll);
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
            playerTransform.position += playerTransform.forward * speed * Time.smoothDeltaTime * Input.GetAxis("Vertical");
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
