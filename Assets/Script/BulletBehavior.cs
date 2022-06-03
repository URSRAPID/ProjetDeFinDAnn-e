using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("OnDisable", 2.0f); 
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }

}
