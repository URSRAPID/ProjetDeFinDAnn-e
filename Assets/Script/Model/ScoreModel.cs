using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel 
{
    private FloatObservableScore score;



    public ScoreModel()
    {
        score = new FloatObservableScore(0);

    }
    public void AddScore(float deltaScore)
    {
        score.Add(deltaScore);
    }

    public FloatObservableScore GetScore()
    {
        return score;
    }
}
