﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int health;
	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0) {
        }
	
	}
    void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "Enemy")
        {
            
        }
    }
}
