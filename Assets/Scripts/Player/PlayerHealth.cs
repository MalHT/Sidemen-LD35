using UnityEngine;
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;



        }
    }


}
