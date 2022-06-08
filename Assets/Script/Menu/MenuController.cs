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
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

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


}
