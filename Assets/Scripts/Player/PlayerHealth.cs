using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int healthPlayer;
    public int defensePlayer;
	// Use this for initialization
	void Start () {
        healthPlayer = 100;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (healthPlayer <= 0) {
            Debug.Log("DEAD");
        }
	
	}
}
