using UnityEngine;
using System;
using System.Collections;
using System.Collections.Specialized;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {

    public class Level
    {
        public int Rows;
        public int Columns;
        public GameObject[] floorTiles;
        public GameObject[] outerWallTiles;
        public GameObject[] innerWallTiles;

    }

    void CreateLevel()
    {
        // Create level as a 2d array

        //int Rows = Int32.Parse(Level["Rows"]);
        //int Columns = Int32.Parse(Level["Columns"]);

        int rows = 10;
        int cols = 10;

        string[,] tiles = new string[rows, cols];

        // Create start and exit

        int startPosition = Random.Range(1, cols -1);

        tiles[rows, startPosition] = "s";

        // Create a path of floor tiles to the exit first thing, so it may never be obstructed



        // Place obstacles and other inner tiles

        // Create outer boundaries

        //GameObject[]

        for (int row = 0; row < rows; row++)
        {

            for (int col = 0; col < cols; col++)
            {

                if (tiles[row, col] == "")
                {
                    tiles[row, col] = "e";
                }

                Console.Write(tiles[row, col]);

                if (col == cols -1)
                {
                    Console.WriteLine(" ");
                }

            }

        }



    }

	// Use this for initialization
	void Start () {

        //var exampleLevel = new Level();

        //exampleLevel.Rows = 10;
        //exampleLevel.Columns = 10;
        //exampleLevel.floorTiles = []

        CreateLevel();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
