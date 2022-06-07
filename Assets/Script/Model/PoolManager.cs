using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // waht object to instantiate 
    public GameObject bulletHolePrefab;
    public int spawnCount;
    public Transform firePoint;

    //list of objects that can be used 
    public List<GameObject> bulletHoleList;
    
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
           GameObject bullet = Instantiate(bulletHolePrefab, firePoint.transform.position, firePoint.transform.rotation);
            bulletHoleList.Add(bullet);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
        }  
    }

    
}
