using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Gestion du volume dans le menu.
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");

        Debug.Log("START");
    }


    public void Options()
    {
        Debug.Log("clique options d�tect�");

        Debug.Log("OPTIONS");
    }


    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("QUIT");
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneName);
    }

    public void LevelSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }


}
