using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed);
        }
    }

}