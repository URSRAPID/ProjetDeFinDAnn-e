using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModel
{
    public VectorObservable _position;
    private FloatObservable _life;


    public BossModel( float initLife, float maxLife)
    {
        //_position = new VectorObservable(x, y);
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
