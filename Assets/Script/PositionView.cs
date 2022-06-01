using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionView : MonoBehaviour, IObserver<VectorObservable>
{

    [SerializeField] GameObject _character;
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }


    public void OnNext(VectorObservable value)
    {
        _character.transform.position = value;
    }
}
