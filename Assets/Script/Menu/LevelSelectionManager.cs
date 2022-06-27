using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionManager : MonoBehaviour
{
    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Dialogue");

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
