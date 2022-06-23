using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabPowerUp;
    [SerializeField] public GameObject _spawnPointPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            PowerUp();
        }
       
        
    }

    private void PowerUp()
    {
        Debug.Log(_spawnPointPowerUp.transform.position);
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUp, whereToSpawn, Quaternion.identity);
        clientSpecial.transform.SetParent(_spawnPointPowerUp.transform);
    }
}
