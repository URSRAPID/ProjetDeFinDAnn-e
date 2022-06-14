using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpView : MonoBehaviour, IObserver<FloatNormalizable>
{
    [SerializeField] public Image MpImage;
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
        MpImage.fillAmount = value.Normalize();
    }

   
}
