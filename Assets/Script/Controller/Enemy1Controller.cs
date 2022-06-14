using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalleCharacter" )
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "BouclierCharacter" )
        {
            Destroy(gameObject);
        }
        else if ( collision.gameObject.tag == "Character")
        {
            Destroy(gameObject);
        }
    }
}
