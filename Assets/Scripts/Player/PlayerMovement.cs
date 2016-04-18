using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    private string moveDirection = "none";

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);

            if (moveDirection != "left") {
                moveDirection = "left";
                gameObject.GetComponent<Animator>().Play("MovingLeft");
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);

            if (moveDirection != "right")
            {
                moveDirection = "right";
                gameObject.GetComponent<Animator>().Play("MovingRight");
            }

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);

            if (moveDirection != "up")
            {
                moveDirection = "up";
                gameObject.GetComponent<Animator>().Play("MovingUp");
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed);

            if (moveDirection != "down")
            {
                moveDirection = "down";
                gameObject.GetComponent<Animator>().Play("MovingDown");
            }

        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {

            if (moveDirection != "none")
            {
                moveDirection = "none";
                gameObject.GetComponent<Animator>().Play("Idle");
            }

        }
    }

}