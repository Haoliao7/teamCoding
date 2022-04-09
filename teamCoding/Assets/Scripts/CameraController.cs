using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player; //player position

    // Update is called once per frame
    private void Update()
    {

        if (player.position.y > -0.2f)
        {
            transform.position = new Vector3(0, player.position.y, -10); //follow player
        }
    }
}