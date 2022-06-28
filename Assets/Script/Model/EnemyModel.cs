using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private FloatObservable _life;

    public EnemyModel(float initLife, float maxLife)
    {
        _life = new FloatObservable(initLife, maxLife);
    }
    public void AddLife(float deltaLife)
    {
        _life.Add(deltaLife);
    }
    public FloatObservable GetLife()
    {
        return _life;
    }
}
