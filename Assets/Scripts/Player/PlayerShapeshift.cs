using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShapeshift : MonoBehaviour {
    public string form;
    public int attack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Base Form Switch
        if (Input.GetKey(KeyCode.U))
        {
            if (form != "base")
            {
                form = "base";
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                gameObject.GetComponent<PlayerMovement>().speed = 0.05F;
                gameObject.GetComponent<PlayerHealth>().defensePlayer = 10;
                attack = 10;
            }
        }
        // Bear Form Switch
        if (Input.GetKey(KeyCode.I))
        {
            if (form != "bear")
            {
                form = "bear";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                gameObject.GetComponent<PlayerMovement>().speed = 0.025F;
                gameObject.GetComponent<PlayerHealth>().defensePlayer = 7;
                attack = 20;
            }
        }
        // Turtle Form Switch
        if (Input.GetKey(KeyCode.O))
        {
            if (form != "turtle")
            {
                form = "turtle";
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                gameObject.GetComponent<PlayerMovement>().speed = 0.0125F;
                gameObject.GetComponent<PlayerHealth>().defensePlayer = 15;
                attack = 5;
            }
        }
        // Leopard Form Switch
        if (Input.GetKey(KeyCode.P))
        {
            if (form != "leopard")
            {
                form = "leopard";
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                gameObject.GetComponent<PlayerMovement>().speed = 0.075F;
                gameObject.GetComponent<PlayerHealth>().defensePlayer = 5;
                attack = 5;
            }
        }



    }
}
