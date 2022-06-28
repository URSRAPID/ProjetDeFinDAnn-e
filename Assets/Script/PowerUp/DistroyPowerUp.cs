using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyPowerUp : MonoBehaviour
{
    public float _destroy = 10;
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
        Invoke("OnDisable", _destroy); 
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
