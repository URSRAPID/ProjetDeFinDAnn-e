using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Vector2 _speedBullet;
  
    private void Update()
    {
        
        transform.position = transform.position + (Vector3)_speedBullet * Time.deltaTime;
        
    }

    void OnEnable()
    {
        //Invoke("OnDisable", 5.0f); 
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BoxBalle")
        {
            OnDisable();
        }
        if (collision.gameObject.tag == "ArmureBoss")
        {
            OnDisable();
        }
        
        
    }
}
