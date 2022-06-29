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
        SaveDataScript.Refresh();
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1;

        Debug.Log("START");
    }
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1;

        Debug.Log("START");
    }

    public void Options()
    {
        Debug.Log("clique options détecté");

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
        Time.timeScale = 1;
    }

    public void LevelSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Next()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1;
    }



}
