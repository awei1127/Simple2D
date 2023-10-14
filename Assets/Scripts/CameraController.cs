using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
