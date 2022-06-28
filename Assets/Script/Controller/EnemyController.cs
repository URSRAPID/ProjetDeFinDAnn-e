using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{


    [SerializeField] private float cooldownSpawnPool;

    private PoolManagerEnemy _pool;
    public Transform firePoint;

    private float currentCoolDown;
    private bool _isActive = false;
    //public float bulletSpeed = 10f;

    int powerUpLiefOuMp;
    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabPowerUpLife;
    [SerializeField] public GameObject _spawnPrefabPowerUpMP;
    [SerializeField] public GameObject _spawnPointPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManagerEnemy>();
        if (cooldownSpawnPool == 0)
        {
            cooldownSpawnPool = 1;

        }
        currentCoolDown = cooldownSpawnPool;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive == true)
        {
            currentCoolDown -= Time.deltaTime;
            if (currentCoolDown <= 0)
            {

                Debug.Log("Am Tras2");
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalleCharacter" || collision.gameObject.tag == "BouclierCharacter")
        {
            Destroy(gameObject);
            powerUpLiefOuMp = Random.Range(0, 3);

            if (powerUpLiefOuMp == 2)
            {
                SpawnPowerUpLife();
            }
            else if (powerUpLiefOuMp == 1)
            {
                SpawnPowerUpMp();
            }
            Debug.Log(powerUpLiefOuMp);
        }
        else if(collision.gameObject.tag == "BoxBalle")
        {
            _isActive = true;
        }
        else if(collision.gameObject.tag == "BoxIsActive")
        {
            Destroy(gameObject);
            _isActive = false;
           
        }
    }

    private void SpawnPowerUpLife()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUpLife, whereToSpawn, Quaternion.identity);
        clientSpecial.transform.SetParent(_spawnPointPowerUp.transform);
    }
    private void SpawnPowerUpMp()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUpMP, whereToSpawn, Quaternion.identity);
        clientSpecial.transform.SetParent(_spawnPointPowerUp.transform);
    }
}
