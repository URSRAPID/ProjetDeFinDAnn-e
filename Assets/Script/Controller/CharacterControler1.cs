using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{


    private float speed = 5;

    void Update()
    {
        transform.Translate(
          Input.GetAxis("Horizontal") * speed * Time.deltaTime,
          Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

    }

    
}

