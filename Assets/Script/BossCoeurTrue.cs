using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoeurTrue : MonoBehaviour
{
    public GameObject MurBoss;
    public GameObject Boss;
    public GameObject BossC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MurBoss)
        { 
            Destroy(Boss);
            BossC.gameObject.SetActive(true);
        }
    }
}
