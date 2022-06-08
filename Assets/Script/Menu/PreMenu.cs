using UnityEngine;
using System.Collections;

public class PreMenu : MonoBehaviour
{

    public AudioClip sfxButton;

    private bool oneshotSfx;

    public GameObject preMenu;


    void Update()
    {
        if (Input.anyKey)
        {
            LaunchGame();
            
        }


    }
    // Update is called once per frame
    void LaunchGame()
    {
        preMenu.SetActive(false);
    }

}