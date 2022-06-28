using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Invoke("OnDisable", 10.0f); 
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
