
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private float cooldownSpawnPool;

    private PoolManager _pool;

    public Transform firePoint;

    private float currentCoolDown;

    [SerializeField] private bool _isActive;

    private BouclierView bouclier;


    [SerializeField]
    int numberOfProjectiles;

    Vector2 startPoint;

    float radius;


    [SerializeField]
    float angleShoot;

    [SerializeField]
    float moveSpeed;

    // AUDIO SOURCE WHEN WE SHOOT
    public AudioSource shoot;

    // ANIMATION 
    Animator animator;
    int isShootingHash;
    
    



    void Start()
    {
        // ANIMATION 

        animator = GetComponent<Animator>();

        isShootingHash = Animator.StringToHash("isShooting");
        



        radius = 5f;


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
        // ANIMATION

        bool isShooting = animator.GetBool(isShootingHash);
        

        
        if (Input.GetMouseButton(0))
        {
            animator.SetBool(isShootingHash, false);
            
        }
        else
        {
            if (_isActive == true)
            {
                animator.SetBool(isShootingHash, true);
                currentCoolDown -= Time.deltaTime;
                if (currentCoolDown <= 0)
                {

                    Shooter(numberOfProjectiles);
                    

                    currentCoolDown = cooldownSpawnPool;
                    currentCoolDown++;
                    shoot.Play();

                }
            }
        }

    }


    void Shooter(int numberOfProjectiles)
    {
        float angle2 = angleShoot;
        if (numberOfProjectiles == 1)
        {
            angle2 = 0f;
        }
        if (numberOfProjectiles == 2)
        {
            angle2 = 1.7f;
        }
        float angleStep = angle2 / (numberOfProjectiles - 1);
        float angle = 90f - angle2 / 2f;

        // Instantiate bullet holes
        // Iterate through the bullet hole pool list 
        // find an object that's active == false 
        // set it to enable 
        // position of the object matches hitInfo Point 
        // Adjust rotation to surface normal 

        for (int j = 0; j <= numberOfProjectiles - 1; j++)
        {

            for (int i = 0; i < _pool.bulletHoleList.Count; i++)
            {
                if (_pool.bulletHoleList[i].activeInHierarchy == false)
                {
                    _pool.bulletHoleList[i].SetActive(true);
                    _pool.bulletHoleList[i].transform.position = firePoint.transform.position;
                    float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                    float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
                    Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
                    Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

                    _pool.bulletHoleList[i].GetComponent<BulletBehavior>()._speedBullet = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
                    //_pool.bulletHoleList[i].transform.rotation = firePoint.transform.rotation;
                    /*rb = _pool.bulletHoleList[i].GetComponent<Rigidbody2D>();
                    Vector2 force = transform.right * bulletSpeed;
                    rb.AddForce(force, ForceMode2D.Impulse);*/
                    angle += angleStep;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BoxFireActive")
        {
            _isActive = true;
            Debug.Log("OnCollisionEnter2D");
        }
        if (collision.gameObject.tag == "PowerUpGunCharacter")
        {
            numberOfProjectiles = numberOfProjectiles + 1;
        }
    }


}
