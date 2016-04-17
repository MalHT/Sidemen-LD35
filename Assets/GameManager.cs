using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public LevelManager levelManager;

    private int level = 1;

    public void nextLevel()
    {
        level = level + 1;

        Debug.Log("Next level is " + level);
        Debug.Log(levelManager);

        levelManager.makeLevelNumber(level);

        

    }

	// Use this for initialization

	void Awake () {

        levelManager = GetComponent<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
