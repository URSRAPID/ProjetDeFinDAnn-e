using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCharacter : MonoBehaviour
{

    [SerializeField] private GameObject powerUpButton;
    // Start is called before the first frame update
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Character")
        {
            Debug.Log("OUI");
            powerUpButton.SetActive(true);
            Debug.Log("OUI");
            Destroy(gameObject);
            Debug.Log("OUI");
        }
    }
}
