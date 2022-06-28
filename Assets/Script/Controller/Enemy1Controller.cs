using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy1Controller : MonoBehaviour
{
    int powerUpLiefOuMp;

    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabPowerUpLife;
    [SerializeField] public GameObject _spawnPrefabPowerUpMP;
    [SerializeField] public GameObject _spawnPointPowerUp;


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
        if (collision.gameObject.tag == "BalleCharacter" )
        {
            
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
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "BouclierCharacter" )
        {
           
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
            Destroy(gameObject);
        }
        else if ( collision.gameObject.tag == "Character")
        {
           
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
            Destroy(gameObject);
        }
    }

    private void SpawnPowerUpLife()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUpLife, whereToSpawn, Quaternion.identity);
    }
    private void SpawnPowerUpMp()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUpMP, whereToSpawn, Quaternion.identity);
    }
}
