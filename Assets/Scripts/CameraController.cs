using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // to refere player
    public GameObject player;
    // it is private so that we can set it's value here in script
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // we will subtrat player position from camera position
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // so in every frame we will set our cameras transform position to offset plus our player's position
        // so camera will move with player aligned with it just as if it were child of that object 
        transform.position = player.transform.position + offset;
    }
}
