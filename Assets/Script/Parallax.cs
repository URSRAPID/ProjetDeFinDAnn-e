using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float _speedCam = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        if(temp > startpos + length) startpos += length;
        else if(temp < startpos - length) startpos -= length;

        cam.transform.position = cam.transform.position - new Vector3(_speedCam * Time.deltaTime, 0f, 0f);
        if(cam.transform.position.x < -length)
        {
            cam.transform.position += new Vector3(length, 0f, 0f);
        }
        
    }
}
