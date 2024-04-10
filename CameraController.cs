using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // reference the player game object's position
    public GameObject player;
    // store the offset value. private because I'll set the value in the script
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // set offset equal to camera transform position minus player game object's transform position
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after other updates are done
    void LateUpdate()
    {
        // camera game object moved into new position aligned with player game object before frame is displayed
        // matches position but not rotation of sphere
        transform.position = player.transform.position + offset;
    }
}
