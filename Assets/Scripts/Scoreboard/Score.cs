using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class Score
{
    public string player_name;
    public float score;

    public Score(string player_name, float score) 
    {
        this.player_name = player_name;
        this.score = score;
    }
}
