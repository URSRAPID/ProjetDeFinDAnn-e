using UnityEngine;


public class Mur2BossActiveCanons : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    
    public float anglesBossPrefab;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

        ActiveShootMur2Boss();
    }

    void ActiveShootMur2Boss()
    {
        if (bossPrefab.transform.eulerAngles.z == anglesBossPrefab)
        {
           
            this.gameObject.SetActive(false);
        }
       
    }


}
