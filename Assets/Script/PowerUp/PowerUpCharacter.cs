using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCharacter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Character")
        {                    
            GameObject.FindObjectOfType<PauseMenu>().powerUpButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
