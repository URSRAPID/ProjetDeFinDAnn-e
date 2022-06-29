using UnityEngine;


public class Mur2BossActiveCanons : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    
    public float anglesBossPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (bossPrefab.transform.eulerAngles.z == anglesBossPrefab)
        {

            this.gameObject.SetActive(false);
        }

    }




}
