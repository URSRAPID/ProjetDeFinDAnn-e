
using UnityEngine;

public class CharacterModel 
{
    public VectorObservable _position;
    private FloatObservable _life;
    private FloatObservable _mp;

    private float speed = 5;

    public CharacterModel(float x, float y, float initLife, float maxLife, float initMp, float maxMp)
    {
        _position = new VectorObservable(x , y);
        _life = new FloatObservable(initLife, maxLife);
        _mp = new FloatObservable(initMp, maxMp);
    }

    public void AddPosition(Vector2 deltaPosition)
    {
        _position.Add(deltaPosition);
    }
    public void AddLife(float deltaLife)
    {
        _life.Add(deltaLife);
    }

    public void AddMp(float deltaLife)
    {
        _mp.Add(deltaLife);
    }

   

    public VectorObservable GetPosition()
    {
        return _position;
    }

    public FloatObservable GetLife()
    {
        return _life;
    }

    public FloatObservable GetMp()
    {
        return _mp;
    }

}
