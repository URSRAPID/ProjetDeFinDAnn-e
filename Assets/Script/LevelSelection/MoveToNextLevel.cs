using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        



        if (other.gameObject.tag == "Character")
        {

            if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                Debug.Log("finish the game");

                // ici je joue l'animation de fin du jeu
            }

            else
            {
                WinPanel.SetActive(true);
                Time.timeScale = 0;

                // ici je pop up la win scene, animation, music etc

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }

            


            
        }
        

        
    }

}
