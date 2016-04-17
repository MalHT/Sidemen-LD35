using UnityEngine;
using System.Collections;

public class ExitTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {

        // if collides with player (todo)

        gameManager.nextLevel();

    }

    void Start()
    {

        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

    }

}
