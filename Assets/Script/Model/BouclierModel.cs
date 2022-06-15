
using UnityEngine;

public class BouclierModel 
{
    public VectorObservable _position;

    public BouclierModel(float x , float y)
    {
        _position = new VectorObservable(x, y);
    }

    public void AddPosition(Vector2 deltaPosition)
    {
        _position.Add(deltaPosition);
    }

    public VectorObservable GetPosition()
    {
        return _position;
    }
}
