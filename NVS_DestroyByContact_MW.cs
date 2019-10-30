using UnityEngine;

public class NVS_DestroyByContact_MW : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private NVS_GameController_MW nvs_GameController_MW;

    private void Start()
    {
        GameObject nvs_GameController_MW_Object = GameObject.FindWithTag("NVS_GameController");
        if (nvs_GameController_MW_Object != null)
        {
            nvs_GameController_MW = nvs_GameController_MW_Object.GetComponent<NVS_GameController_MW>();
        }
        if (nvs_GameController_MW_Object == null)
        {
            Debug.Log("Cannot find 'NVS_GameController_MW' script");
        }
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") 
            || other.CompareTag("PickUp_RedDiamond") || other.CompareTag("PickUp_Credits"))
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
            nvs_GameController_MW.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
