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
    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;



        }
    }


}
