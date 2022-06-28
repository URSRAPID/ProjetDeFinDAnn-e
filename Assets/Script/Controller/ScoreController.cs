using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class ScoreController : MonoBehaviour
{

    private ScoreModel _scoreModel;
    //[SerializeField] public EnemyController _enemyController ;

    [SerializeField] private FloatView _scoreView;
    // Start is called before the first frame update
    void Start()
    {
        _scoreModel = new ScoreModel();
        _scoreModel.GetScore().Subscribe(_scoreView);
    }

    // Update is called once per frame
    void Update()
    {
        //AddScoreEnemy();
    }

    public void AddScoreEnemy(EnemyController _enemyController)
    {
        Debug.Log("Oui");
        if (_enemyController != null && _enemyController.GetIsDead() == true)
        {
            Debug.Log("Oui2");
            _scoreModel.AddScore(60);
            Destroy(_enemyController.gameObject);
        }
    }

    public void AddScoreEnemy2(Enemy1Controller _enemy1Controller)
    {
        Debug.Log("Oui1");
        if (_enemy1Controller != null && _enemy1Controller.GetIsDead() == true)
        {
            Debug.Log("Oui3");
            _scoreModel.AddScore(30);
            Destroy(_enemy1Controller.gameObject);
        }
    }
    public void AddScoreEnemy3(Enemy2Controller _enemy2Controller)
    {
        Debug.Log("Oui1");
        if (_enemy2Controller != null && _enemy2Controller.GetIsDead() == true)
        {
            Debug.Log("Oui3");
            _scoreModel.AddScore(30);
            Destroy(_enemy2Controller.gameObject);
        }
    }
}
