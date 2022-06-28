using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPowerUp : MonoBehaviour
{
    [SerializeField] PowerUpIsActive powerup;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PowerUp()
    {
        powerup.gameObject.SetActive(true);
    }
}
