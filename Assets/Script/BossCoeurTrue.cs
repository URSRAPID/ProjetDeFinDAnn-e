using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCoeurTrue : MonoBehaviour
{
    public GameObject MurBoss;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MurBoss)
        { 
            Destroy(Boss);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 4");
        }
    }
}
