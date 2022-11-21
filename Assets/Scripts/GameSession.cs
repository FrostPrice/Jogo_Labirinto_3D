using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public Config config;

    // Start is called before the first frame update
    void Start()
    {
        config.timer = 0.000000f;
        GameObject pause_menu_canvas = GameObject.Find("Pause Menu");
        pause_menu_canvas.GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        Timer_Counter();
    }

    public void Timer_Counter() {
        config.timer += Time.deltaTime;
    }
}
