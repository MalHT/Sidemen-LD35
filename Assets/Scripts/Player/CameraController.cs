using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private GameObject player;
    private Vector3 offset;
    private bool playerSearching = true;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");

        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

            //transform.position = new Vector2(0, 0);

            //Debug.Log("Found a player instance to track");

            //player = players[0];

            //offset = transform.position - player.transform.position;

            //transform.position = player.transform.position + offset;

            //transform.LookAt(player.transform);


    }
}
