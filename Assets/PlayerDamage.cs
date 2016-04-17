﻿using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
    public Transform Player;
    public float ChaseSpeed = 0.05f;
    public float Range = 0.05f;
    float CurrentSpeed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, Player.position) <= Range) // check the distance between this game object and Player and continue if it's less than Range
        {
            CurrentSpeed = ChaseSpeed * Time.deltaTime; // set the CurrentSpeed to ChaseSpeed and multiply by Time.deltaTime (this prevents it from moving based on FPS)
            transform.position = Vector3.MoveTowards(transform.position, Player.position, CurrentSpeed);  // set this game objects position to the Player's position at the speed of CurrentSpeed
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            other.gameObject.GetComponent<PlayerHealth>().healthPlayer = other.gameObject.GetComponent<PlayerHealth>().healthPlayer - 20;
            Debug.Log(other.gameObject.GetComponent<PlayerHealth>().healthPlayer);
            




        }
    }
}
