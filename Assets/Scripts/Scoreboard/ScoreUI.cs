using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public RowUI row_ui;
    public ScoreController score_controller;

    // Start is called before the first frame update
    void Start()
    {       
        Score[] scores = score_controller.sort_in_ascending_order().ToArray();

        for (int i = 0; i < scores.Length; i++) {
           RowUI row = Instantiate(row_ui, transform).GetComponent<RowUI>();
           row.rank.text = (i + 1).ToString();
           row.player_name.text = scores[i].player_name;
           row.score.text = scores[i].score.ToString();
        }
    }
}
