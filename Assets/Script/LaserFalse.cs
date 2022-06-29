using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFalse : MonoBehaviour
{
    [SerializeField] private float cooldownSpawnLaser;
    private float currentCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        if (cooldownSpawnLaser == 0)
        {
            cooldownSpawnLaser = 1;

        }
        currentCoolDown = cooldownSpawnLaser;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.active == true)
        {
            desactive();
        }
    }

    void desactive()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0)
        {
            this.gameObject.SetActive(false);
            currentCoolDown = cooldownSpawnLaser;
            currentCoolDown++;

        }
        
    }
}
