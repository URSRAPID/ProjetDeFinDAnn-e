using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeView : MonoBehaviour, IObserver<FloatNormalizable>
{
    [SerializeField] public Image lifeImage;

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(FloatNormalizable value)
    {
        lifeImage.fillAmount = value.Normalize();
    }
}
