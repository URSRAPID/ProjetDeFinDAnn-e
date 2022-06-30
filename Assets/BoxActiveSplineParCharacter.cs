using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActiveSplineParCharacter : MonoBehaviour
{
    [SerializeField] private GameObject spline;
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

        if (collision.gameObject.tag == "Character")
        {
            spline.gameObject.SetActive(true);
        }
    }
}
