using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class InputEvent : MonoBehaviour
{
    public Config config;
    public ScoreController score_controller;
    public TextMeshProUGUI input;
    private bool stop_input = false;

    private string get_text() {
        return input.text;
    }

    public void save_time_btn() 
    {
        string player_name = get_text();
        if(!string.IsNullOrWhiteSpace(player_name)) {
            stop_input = true;
            score_controller.add_score(new Score(player_name, config.timer));
            if(stop_input) {
                GameObject save_scoreboard_field = GameObject.Find("Save Scoreboard Background");
                save_scoreboard_field.GetComponent<CanvasGroup>().interactable = false;
            }
        }
    }
}
