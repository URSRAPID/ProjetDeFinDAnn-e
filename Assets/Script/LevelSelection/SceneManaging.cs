using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManaging : MonoBehaviour
{
    
    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

    }

    public void Level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");

    }

    public void Level3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");

    }
}
