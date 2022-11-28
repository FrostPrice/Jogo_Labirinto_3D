using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class ItemController : MonoBehaviour
{
    public Config config;
    public GameObject item;
    public GameObject player_1;
    public GameObject player_1_light;
    public GameObject player_2;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        set_item_coords();    
    }

    void set_item_coords() {
        for (int i=0; i<config.lin; i++) {
            for (int j=0; j<config.col; j++) {
                if (config.mapa[i,j] == 4){
                    Vector3 spawnPos = new Vector3(i-20f, 2, j-20f);
                    Instantiate(item, spawnPos, Quaternion.identity);
                }
            }    
        }
    }

    public void execute_random_power() {
        // int random_number = Random.Range(0, 8);
        int random_number = Random.Range(7, 8);

        switch(random_number) {
            case 0:
                StartCoroutine(invert_control(10));
                break;
            case 1:
                StartCoroutine(stop_movement(10));
                break;
            case 2:
                StartCoroutine(increase_movement(10));
                break;
            case 3:
                StartCoroutine(reduce_view(10));
                break;
            case 4:
                rotate_camera(90.0f);
                break;
            case 5:
                StartCoroutine(turn_screen_black(7));
                break;
            case 6:
                StartCoroutine(turn_small(10));
                break;
            case 7:
                teleport_player();
                break;
        }
    }

    private IEnumerator invert_control(int seconds)
    {
        player_1.GetComponent<PlayerController>().velocity = -5;
        yield return new WaitForSeconds(seconds);
        player_1.GetComponent<PlayerController>().velocity = 5;
    }
    private IEnumerator stop_movement(int seconds) {
        player_1.GetComponent<PlayerController>().velocity = 0;
        yield return new WaitForSeconds(seconds);
        player_1.GetComponent<PlayerController>().velocity = 5;
    }
    private IEnumerator increase_movement(int seconds) {
        player_2.GetComponent<PlayerController>().velocity = 7;
        yield return new WaitForSeconds(seconds);
        player_2.GetComponent<PlayerController>().velocity = 5;
    }
    private void teleport_player() {
        int random_x, random_y;
        int[,] map = config.mapa;

        do {
            random_x = Random.Range(0, config.col - 1);
            random_y = Random.Range(0, config.lin - 1);
        } while(map[random_y, random_x] != 0);

        player_2.transform.position = new Vector3((float)random_y - 20.0f, 2.0f, (float)random_x - 20.0f);
    }
    private IEnumerator reduce_view(int seconds) {
        player_1_light.GetComponent<Light>().spotAngle = 10;
        yield return new WaitForSeconds(seconds);
        player_1_light.GetComponent<Light>().spotAngle  = 70;
    }
    private IEnumerator turn_small(int seconds) {
        Vector3 min_scale = new Vector3(0.3f, 0.3f, 0.3f);
        Vector3 max_scale = new Vector3(0.75f, 0.75f, 0.75f);

        player_1.transform.localScale = min_scale;
        player_1_light.GetComponent<Light>().intensity = 1f;
        yield return new WaitForSeconds(seconds);
        player_1_light.GetComponent<Light>().intensity = 2.5f;
        player_1.transform.localScale = max_scale;
    }
    private void rotate_camera(float degree) {
        player_1.transform.Rotate(0.0f, player_1.transform.rotation.y + degree, 0.0f);
    }
    private IEnumerator turn_screen_black(int seconds) {
        GameObject player_1_screen_black = GameObject.Find("Player_1_Screen_Black");
        player_1_screen_black.GetComponent<CanvasGroup>().alpha = 1;
        yield return new WaitForSeconds(seconds);
        player_1_screen_black.GetComponent<CanvasGroup>().alpha = 0;
    }
}
