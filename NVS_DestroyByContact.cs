using UnityEngine;

public class NVS_DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private NVS_GameController nvs_GameController;
    
    // Use this for initialization
	void Start ()
    {
        GameObject nvs_GameControllerObject = GameObject.FindWithTag("NVS_GameController");
        if (nvs_GameControllerObject != null)
        {
            nvs_GameController = nvs_GameControllerObject.GetComponent<NVS_GameController>();
        }
        if (nvs_GameControllerObject == null)
        {
            Debug.Log("Cannot find 'NVS_GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || 
            other.CompareTag("PickUp_RedDiamond") || other.CompareTag("PickUp_Credits"))
        {
            return;
        }

        if (other.gameObject.CompareTag("PickUp_RedDiamond") || other.CompareTag("PickUp_Credits"))
        {
            other.gameObject.SetActive(false);
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
                
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            nvs_GameController.GameOver();
        }
                
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
