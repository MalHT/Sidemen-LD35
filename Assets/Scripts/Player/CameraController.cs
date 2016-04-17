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

        if (playerSearching)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            if (players.Length > 0) {

                player = players[0];

                offset = transform.position - player.transform.position;

                transform.position = player.transform.position + offset;

                playerSearching = false;

            }
            
        }
        else {

            transform.position = player.transform.position + offset;

        }
	
	}
}
