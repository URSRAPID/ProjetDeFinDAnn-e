using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControler1 : MonoBehaviour
{
    [SerializeField]
    private Transform _turretBarrel;

    [SerializeField] private GameObject[] _bulletHolePrefabs;

    private PoolManager _pool;

    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
          Input.GetAxis("Horizontal") * speed * Time.deltaTime,
          Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
      
    }

     void FixedUpdate()
    {
        Debug.Log("Pregatiti de tras");
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Am Tras");
            Shoot();
        }
    }
    void Shoot()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(rayOrigin, out hitInfo))
        {
            if(hitInfo.collider.tag == "Ennemi")
            {
                // Assing Random Bullet 
                GameObject bulletHoleToUse = _bulletHolePrefabs[Random.Range(0, _bulletHolePrefabs.Length)];

                // Instantiate bullet holes
                // Iterate through the bullet hole pool list 
                // find an object that's active == false 
                // set it to enable 
                // position of the object matches hitInfo Point 
                // Adjust rotation to surface normal 

                //Instantiate(bulletHoleToUse, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                for (int i = 0; i < _pool.bulletHoleList.Count; i++)
                {
                    if (_pool.bulletHoleList[i].activeInHierarchy == false)
                    {
                        _pool.bulletHoleList[i].SetActive(true);
                        _pool.bulletHoleList[i].transform.position = hitInfo.point;
                        _pool.bulletHoleList[i].transform.rotation = Quaternion.LookRotation(hitInfo.normal);
                        break;
                    }
                    else
                    {
                        //create a new bullet. ONLY if we're on the last item of the list 
                        if (i == _pool.bulletHoleList.Count - 1)
                        {
                            // Last Bullet 
                            GameObject newBullet = Instantiate(_pool.bulletHolePrefab) as GameObject;
                            newBullet.transform.parent = _pool.transform;
                            newBullet.SetActive(false);
                            _pool.bulletHoleList.Add(newBullet);
                        }
                    }
                }
                //Direction = destion - source
                Vector2 direction = hitInfo.point - _turretBarrel.position;
                _turretBarrel.rotation = Quaternion.LookRotation(direction);

            }
        }
    }
}
