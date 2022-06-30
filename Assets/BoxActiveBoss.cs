using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActiveBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
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

        if (collision.gameObject.tag == "BoxBalle")
        {
            Boss.gameObject.SetActive(true);
        }
    }
}
