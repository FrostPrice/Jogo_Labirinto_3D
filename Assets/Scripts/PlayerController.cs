using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * velocity * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * velocity * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }
    }
}
