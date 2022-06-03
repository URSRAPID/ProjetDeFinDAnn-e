using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // waht object to instantiate 
    public GameObject bulletHolePrefab;
    public int spawnCount;
    //list of objects that can be used 
    public List<GameObject> bulletHoleList;
    
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
           GameObject bullet =  Instantiate(bulletHolePrefab) as GameObject;
            bulletHoleList.Add(bullet);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
