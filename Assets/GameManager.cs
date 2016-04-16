using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public LevelManager levelManager;

    private int level;

	// Use this for initialization
	void Awake () {

        levelManager = GetComponent<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
