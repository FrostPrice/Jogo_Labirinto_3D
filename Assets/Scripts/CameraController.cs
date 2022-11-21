using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 cam_offset = new Vector3(0, 5, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + cam_offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + cam_offset;
    }
}
