using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleViewEnemyTour : MonoBehaviour
{
    public GameObject bullet;
    public float _speedBullet;

    private void Update()
    {

        bullet.transform.position = bullet.transform.position - new Vector3(_speedBullet * Time.deltaTime, 0f, 0f);

    }

    void OnEnable()
    {
        //Invoke("OnDisable", 5.0f);
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            OnDisable();
        }
        else if (collision.gameObject.tag == "BoxIsActive")
        {
            OnDisable();
        }
        else if (collision.gameObject.tag == "BouclierCharacter")
        {
            OnDisable();
        }

    }
}
