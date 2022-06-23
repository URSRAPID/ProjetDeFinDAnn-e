using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonsActive : MonoBehaviour
{
    [SerializeField] private GameObject Canons;
    [SerializeField] private GameObject Canons2;
    [SerializeField] private GameObject Canons3;
    [SerializeField] private GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossPrefab.transform.eulerAngles.z == 90)
        {
            Canons.gameObject.SetActive(true);
        }
        if (bossPrefab.transform.eulerAngles.z == 180)
        {
            Canons2.gameObject.SetActive(true);
        }
        if (bossPrefab.transform.eulerAngles.z == 270)
        {
            Canons3.gameObject.SetActive(true);
        }
    }
}
