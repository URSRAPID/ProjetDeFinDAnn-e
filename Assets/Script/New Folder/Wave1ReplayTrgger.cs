using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1ReplayTrgger : MonoBehaviour
{

    public GameObject vaque;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BoxIsActiveVague")
        {
            vaque.gameObject.SetActive(true);
        }
    }

}
