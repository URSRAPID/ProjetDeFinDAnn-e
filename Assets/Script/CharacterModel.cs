using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel 
{
    public VectorObservable _position;
   public CharacterModel(Vector2 initPosition)
    {
        _position = new VectorObservable(initPosition);
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
