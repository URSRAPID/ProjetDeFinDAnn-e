using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    public List<SpriteRenderer> sprites;
    private int _currentSprite = 0;
    public Transform camera;
    public float deltaPos;

    // Start is called before the first frame update
    void Start()
    {
        length = sprites[0].bounds.size.x;
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (sprites[_currentSprite].transform.position.x < camera.transform.position.x - deltaPos)
        {
            sprites[_currentSprite].transform.position += new Vector3(3*length, 0, 0);
            _currentSprite++;
            if (_currentSprite == sprites.Count)
            {
                _currentSprite = 0;
            }
        }
        
    }
}
