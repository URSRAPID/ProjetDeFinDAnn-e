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
            _scoreModel.AddScore(30);
            Destroy(_enemyController.gameObject);
        }
    }
}
