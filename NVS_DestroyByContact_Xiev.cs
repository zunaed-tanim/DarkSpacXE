using UnityEngine;

public class NVS_DestroyByContact_Xiev : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private NVS_GameController_Xiev nvs_GameController_Xiev;

    // Use this for initialization
    void Start ()
    {
        GameObject nvs_GameController_Xiev_Object = GameObject.FindWithTag("NVS_GameController");
        if (nvs_GameController_Xiev_Object != null)
        {
            nvs_GameController_Xiev = nvs_GameController_Xiev_Object.GetComponent<NVS_GameController_Xiev>();
        }
        if (nvs_GameController_Xiev_Object == null)
        {
            Debug.Log("Cannot find 'NVS_GameController_Xiev' script");
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
            nvs_GameController_Xiev.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
