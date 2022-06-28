using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy1Controller : MonoBehaviour
{
    int powerUpLiefOuMp;

    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabPowerUpLife;
    [SerializeField] public GameObject _spawnPrefabPowerUpMP;
    [SerializeField] public GameObject _spawnPrefabPowerUpCharacter;
    [SerializeField] public GameObject _spawnPointPowerUp;

    [SerializeField] public ScoreController _scoreController;
    private bool _isDead;

    private EnemyModel enemyModel;

    // Start is called before the first frame update
    void Start()
    {
        enemyModel = new EnemyModel(2, 2);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDamage()
    {
        enemyModel.AddLife(-1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalleCharacter")
        {
            OnDamage();
            if (enemyModel.GetLife().GetValue().GetValue() <= 0)
            {
                powerUpLiefOuMp = Random.Range(0, 10);

                if (powerUpLiefOuMp == 2)
                {
                    SpawnPowerUpLife();
                }
                else if (powerUpLiefOuMp == 1)
                {
                    SpawnPowerUpMp();
                }
                else if (powerUpLiefOuMp == 3)
                {
                    SpawnPowerUpCharacter();
                }
                Debug.Log(powerUpLiefOuMp);
                if (!_isDead)
                {
                    _isDead = true;
                    FindObjectOfType<ScoreController>().AddScoreEnemy2(this);
                }
            }
        }
        else if (collision.gameObject.tag == "BouclierCharacter")
        {
            OnDamage();
            OnDamage();
            if (enemyModel.GetLife().GetValue().GetValue() <= 0)
            {

                powerUpLiefOuMp = Random.Range(0, 10);

                if (powerUpLiefOuMp == 2)
                {
                    SpawnPowerUpLife();
                }
                else if (powerUpLiefOuMp == 1)
                {
                    SpawnPowerUpMp();
                }
                else if (powerUpLiefOuMp == 3)
                {
                    SpawnPowerUpCharacter();
                }

                Debug.Log(powerUpLiefOuMp);
                if (!_isDead)
                {
                    _isDead = true;
                    FindObjectOfType<ScoreController>().AddScoreEnemy2(this);
                }
            }
        }
        else if (collision.gameObject.tag == "Character")
        {
            OnDamage();
            OnDamage();
            if (enemyModel.GetLife().GetValue().GetValue() <= 0)
            {

                powerUpLiefOuMp = Random.Range(0, 10);

                if (powerUpLiefOuMp == 2)
                {
                    SpawnPowerUpLife();
                }
                else if (powerUpLiefOuMp == 1)
                {
                    SpawnPowerUpMp();
                }
                else if (powerUpLiefOuMp == 3)
                {
                    SpawnPowerUpCharacter();
                }
                Debug.Log(powerUpLiefOuMp);
                if (!_isDead)
                {
                    _isDead = true;
                    FindObjectOfType<ScoreController>().AddScoreEnemy2(this);
                }
            }
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
    private void SpawnPowerUpCharacter()
    {
        whereToSpawn = new Vector2(_spawnPointPowerUp.transform.position.x, _spawnPointPowerUp.transform.position.y);
        GameObject clientSpecial = Instantiate(_spawnPrefabPowerUpCharacter, whereToSpawn, Quaternion.identity);
    }
    public bool GetIsDead()
    {
        return _isDead;
    }
}
