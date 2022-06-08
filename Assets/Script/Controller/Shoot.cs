
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private float cooldownSpawnPool;

     private PoolManager _pool;
    public Transform firePoint;

    private float currentCoolDown;

    public float bulletSpeed = 10f;

    private float timeSpawn = 2f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
        if (cooldownSpawnPool == 0)
        {
            cooldownSpawnPool = 1;

        }
        currentCoolDown = cooldownSpawnPool;
    }

    // Update is called once per frame
    void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Am Tras");
                Shooter();
                currentCoolDown = cooldownSpawnPool;
                currentCoolDown++;
            }
        }
        
    }


    void Shooter()
    {
        

        // Instantiate bullet holes
        // Iterate through the bullet hole pool list 
        // find an object that's active == false 
        // set it to enable 
        // position of the object matches hitInfo Point 
        // Adjust rotation to surface normal 

        for (int i = 0; i < _pool.bulletHoleList.Count; i++)
        {
            if (_pool.bulletHoleList[i].activeInHierarchy == false)
            {
                _pool.bulletHoleList[i].SetActive(true);
                _pool.bulletHoleList[i].transform.position = firePoint.transform.position;
                //_pool.bulletHoleList[i].transform.rotation = firePoint.transform.rotation;
                rb = _pool.bulletHoleList[i].GetComponent<Rigidbody2D>();
                Vector2 force = transform.right * bulletSpeed;
                rb.AddForce(force, ForceMode2D.Impulse);
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

    }
}
