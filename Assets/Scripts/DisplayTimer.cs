using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTimer : MonoBehaviour
{
    public Config config;
    private TextMeshProUGUI timer_text;

    // Start is called before the first frame update
    void Start()
    {
        timer_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float seconds = config.timer % 60;
        timer_text.text = seconds.ToString();
    }
}
