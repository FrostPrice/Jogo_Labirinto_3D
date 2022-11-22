using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public SceneLoader scene_loader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(gameObject.CompareTag("Seeker Collision") && other.gameObject.CompareTag("Hider")) {
            scene_loader.LoadNextScene();
        }

        if(gameObject.CompareTag("Item") && other.gameObject.CompareTag("Hider")) {
            Destroy(gameObject);
            GameObject game_session = GameObject.Find("Game Session");
            game_session.GetComponent<ItemController>().execute_random_power();
        }
    }
}
