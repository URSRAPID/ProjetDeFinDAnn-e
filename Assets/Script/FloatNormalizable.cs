using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatNormalizable
{
    private float _value;
    private float _max;

    public FloatNormalizable(float initValue, float initMax)
    {
        _value = initValue;
        _max = initMax;
    }

    public float GetValue()
    {
        return _value;
    }

    public void SetValue(float newValue)
    {

        if (_value > _max)
        {
            _value = _max;
        }
        else
        {
            _value = newValue;
        }

    }

    // Return Value Normalize entre 1 et 0 
    public float Normalize()
    {
        return _max == 0 ? 1 : _value / _max;

    }
}
