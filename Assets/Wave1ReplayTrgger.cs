using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1ReplayTrgger : MonoBehaviour
{
    public BoxCollider2D wave1;
    public GameObject truc;
    // Start is called before the first frame update
    void Start()
    {
        if (wave1.isTrigger)
        {
            truc.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

}
