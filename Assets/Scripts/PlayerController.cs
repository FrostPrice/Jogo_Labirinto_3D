using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //necess�rio para leitura do arquivo
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{    
    public Config config;

    [Header("Player Status")] 
    [SerializeField] public int player_id;
    [SerializeField] public float velocity = 10.0f;
    [SerializeField] public string[] keyboard;


    // Start is called before the first frame update
    void Start()
    {                                                                  
        set_player_coords();
    }

    void set_player_coords() {
        for (int i=0; i<20; i++) {
            for (int j=0; j<25; j++) {
                if (config.mapa[i,j] == player_id){
                    Vector3 spawnPos = new Vector3(i-20f, 2, j-20f);
                    gameObject.transform.position = spawnPos;
                }
            }    
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyboard[0])) {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        } else if (Input.GetKey(keyboard[1])) {
            transform.Translate(Vector3.left * velocity * Time.deltaTime);
        } else if (Input.GetKey(keyboard[2])) {
            transform.Translate(Vector3.back * velocity * Time.deltaTime);
        } else if (Input.GetKey(keyboard[3])) {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.P)) {
            Time.timeScale = 0;
            GameObject pause_menu_canvas = GameObject.Find("Pause Menu");
            pause_menu_canvas.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}
