using UnityEngine;
using System.Collections;
using Kino;


public class PreMenu : MonoBehaviour
{

    [SerializeField] public AnalogGlitch GlitchEffect;


    public AudioSource source;
    bool quit = false;
    public AudioClip clip;


    public GameObject preMenu;

    float playerScore = 0;
    int nextScene = 0;

    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        Debug.Log("Waiting for Player score to be >=100 ");
        yield return new WaitUntil(() => Input.anyKey);
        Debug.Log("Player score is >=100. Loading next Level");

        //Increment and Load next scene

        float waitTime = 0.5f;
        yield return wait(waitTime);
        TransitionIn();


        waitTime = 0.5f;
        yield return wait(waitTime);
        TransitionOut();


    }

    IEnumerator wait(float waitTime)
    {
        float counter = 0;

        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
            if (quit)
            {
                //Quit function
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
    }

    void TransitionIn()
    {
        source.PlayOneShot(clip);
        GlitchEffect.scanLineJitter = 0.2f;
        GlitchEffect.colorDrift = 0.2f;
    }

    void TransitionOut()
    {
        preMenu.SetActive(false);
        GlitchEffect.scanLineJitter = 0.2f;
        GlitchEffect.colorDrift = 0;
    }


/*    void Update()
    {
        if (Input.anyKey)
        {
            LaunchGame();



        }


    }*/



    // Update is called once per frame
/*    void LaunchGame()
    {
        source.PlayOneShot(clip);
        GlitchEffect.scanLineJitter = 0.2f;
        GlitchEffect.colorDrift = 0.2f;
        preMenu.SetActive(false);
        GlitchEffect.scanLineJitter = 0.2;
        GlitchEffect.colorDrift = 0;

    }*/

}