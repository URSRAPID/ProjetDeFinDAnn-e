using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCharacter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Character")
        {
            Debug.Log("OUI");
            GameObject.FindObjectOfType<PauseMenu>().powerUpButton.SetActive(true);
            Debug.Log("OUI");
            Destroy(gameObject);
            Debug.Log("OUI");
        }
    }
}
