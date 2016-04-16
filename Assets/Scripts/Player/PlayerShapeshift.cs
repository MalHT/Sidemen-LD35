using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShapeshift : MonoBehaviour {
    public string form;

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
                gameObject.GetComponent<PlayerMovement>().speed = 0.1F;
            }
        }
        // Bear Form Switch
        if (Input.GetKey(KeyCode.I))
        {
            if (form != "bear")
            {
                form = "bear";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                gameObject.GetComponent<PlayerMovement>().speed = 0.05F;
            }
        }
        // Turtle Form Switch
        if (Input.GetKey(KeyCode.O))
        {
            if (form != "turtle")
            {
                form = "turtle";
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                gameObject.GetComponent<PlayerMovement>().speed = 0.025F;
            }
        }
        // Leopard Form Switch
        if (Input.GetKey(KeyCode.P))
        {
            if (form != "leopard")
            {
                form = "leopard";
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                gameObject.GetComponent<PlayerMovement>().speed = 0.2F;
            }
        }



    }
}
