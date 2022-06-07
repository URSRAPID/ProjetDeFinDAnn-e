using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;
    public float _speedBullet;
    private void Update()
    {
         
        bullet.transform.position = bullet.transform.position + new Vector3(_speedBullet * Time.deltaTime , 0f, 0f);
    }

    void OnEnable()
    {
        Invoke("OnDisable", 2.0f); 
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }

 }
