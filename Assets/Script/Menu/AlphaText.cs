using UnityEngine;
using UnityEngine.UI;

public class AlphaText : MonoBehaviour
{
    // Expose the timer field in the inspector
    public float timer;

    // Declare a text field
    private Text text;

    private void Start()
    {
        // Get the Text component attached to this gameObject and assign it to the text field
        text = GetComponent<Text>();
    }

    private void Update()
    {
        // Flash the text
        timer += Time.deltaTime;
        if (timer <= 1)
        {
            GetComponent<Text>().enabled = true;
        }
        if (timer >= 2)
        {
            GetComponent<Text>().enabled = false;
            timer = 0;
        }
    }
}