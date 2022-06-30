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
        if (_enemyController != null && _enemyController.GetIsDead() == true)
        {
            _scoreModel.AddScore(60);
            Destroy(_enemyController.gameObject);
        }
    }

    public void AddScoreEnemy2(Enemy1Controller _enemy1Controller)
    {
        if (_enemy1Controller != null && _enemy1Controller.GetIsDead() == true)
        {
            _scoreModel.AddScore(30);
            Destroy(_enemy1Controller.gameObject);
        }
    }
    public void AddScoreEnemy3(Enemy2Controller _enemy2Controller)
    {
        if (_enemy2Controller != null && _enemy2Controller.GetIsDead() == true)
        {
            _scoreModel.AddScore(30);
            Destroy(_enemy2Controller.gameObject);
        }
    }
    public void AddScoreEnemy4(BossController _bossController)
    {
        if (_bossController != null && _bossController.GetIsDeadOui() == true)
        {
            _scoreModel.AddScore(500);
            Destroy(_bossController.gameObject);
        }
    }
    public void AddScoreEnemy5(BossCoeur _bossController)
    {
        if (_bossController != null && _bossController.GetIsDead() == true)
        {
            _scoreModel.AddScore(50000);
            Destroy(_bossController.gameObject);
        }
    }
    public ScoreModel GetScoreModel()
    {
        return _scoreModel;
    }
}
