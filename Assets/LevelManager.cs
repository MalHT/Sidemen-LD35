using UnityEngine;
using System;
using System.Collections;
using System.Collections.Specialized;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {

    // deadforest, darkforest, infectedforest, lightforest

    public GameObject[] DeadForestFloor;
    //public GameObject[] DarkForestFloor;
    //public GameObject[] InfectedForestFloor;
    //public GameObject[] LightForestFloor;

    public GameObject[] DeadForestWalls;
    //public GameObject[] DarkForestWalls;
    //public GameObject[] InfectedForestWalls;
    //public GameObject[] LightForestWalls;

    public GameObject[] DeadForestInnerWalls;
    //public GameObject[] DarkForestInnerWalls;
    //public GameObject[] InfectedForestInnerWalls;
    //public GameObject[] LightForestInnerWalls;

    public GameObject[] DeadForestPath;
    //public GameObject[] DarkForestPath;
    //public GameObject[] InfectedForestPath;
    //public GameObject[] LightForestPath;

    // Enemies
    public GameObject Slime;

    // Entrance and exit tiles
    public GameObject Entrance;
    public GameObject Exit;

    public class Level
    {
        public int Rows;
        public int Columns;
        public GameObject[] floorTiles;
        public GameObject[] outerWallTiles;
        public GameObject[] innerWallTiles;

    }

    public static string[,] levelBaseGenerator(int rows, int cols, int numEnemies)
    {
        // Create level as a 2d array

        string[,] tiles = new string[rows, cols];

        // Create start and exit

        // Random start
        // int startCol = RandomRange(1, cols - 1);

        // Actually make start in column 2
        int startCol = 2;

        tiles[rows - 1, startCol] = "s";

        int exitCol = Random.Range(1, cols - 1);

        tiles[0, exitCol] = "x";

        // Create a path of floor tiles to the exit first thing, so it may never be obstructed

        // Make our way to the top, going a bit left and right

        // fromTop will always start out as 2 less from rows

        int fromTop = rows - 3;

        // fromRight will always start out as 3 less from cols

        int fromRight = cols - 3;

        // currentRow is the starting position...

        int currentRow = rows - 2;

        int currentCol = startCol;

        while (fromTop > 0)
        {

            int tilesUp = Random.Range(1, fromTop);

            // for (tilesUp) iterations
            for (var i = 0; i < tilesUp; i++)
            {
                // Set as path in tile matrix
                tiles[currentRow, currentCol] = "p";

                // Move up one row
                currentRow--;
            }

            // Reduce fromTop by number of tiles moved up
            fromTop = fromTop - tilesUp;

            // Now move right by a certain amount
            int amountRightMaxRange = 4;

            if (fromRight < 4)
            {
                amountRightMaxRange = fromRight - 2;
            }

            int tilesRight = Random.Range(0, amountRightMaxRange);

            // for (tilesRight) iterations
            for (var i = 0; i < tilesRight; i++)
            {
                tiles[currentRow, currentCol] = "p";
                currentCol++;
            }

            fromRight = fromRight - tilesRight;

        }

        // Ensure top of map is completely clear for guaranteed access to the exit

        for (var i = 1; i < cols - 1; i++)
        {
            tiles[1, i] = "p";
        }

        // Create outer boundaries

        // Top
        for (var i = 0; i < cols; i++)
        {
            if (tiles[0, i] != "x")
            {
                tiles[0, i] = "w";
            }
        }

        // Bottom

        for (var i = 0; i < cols; i++)
        {
            if (tiles[cols - 1, i] != "s")
            {
                tiles[cols - 1, i] = "w";
            }
        }

        // Left

        for (var i = 0; i < rows; i++)
        {
            tiles[i, 0] = "w";
        }

        // Right

        for (var i = 0; i < rows; i++)
        {
            tiles[i, rows - 1] = "w";
        }

        // Fill everything else with "e" for "empty"

        for (int row = 0; row < rows; row++)
        {

            for (int col = 0; col < cols; col++)
            {

                if (String.IsNullOrEmpty(tiles[row, col]))
                {
                    tiles[row, col] = " ";
                }

            }

        }

        // Place obstacles and other inner tiles such as enemies

        int enemiesPlaced = 0;

        while (enemiesPlaced < numEnemies)
        {
            int tryRow = Random.Range(1, rows - 2);
            int tryCol = Random.Range(1, cols - 2);

            if (tiles[tryRow, tryCol] == " " || tiles[tryRow, tryCol] == "p")
            {
                tiles[tryRow, tryCol] = "M";
                enemiesPlaced++;
            }
        }

        int obstaclesPlaced = 0;

        int obstaclesToPlace = (rows * cols) / 6;

        while (obstaclesPlaced < obstaclesToPlace)
        {
            int tryRow = Random.Range(1, rows - 2);
            int tryCol = Random.Range(1, cols - 2);

            if (tiles[tryRow, tryCol] == " ")
            {
                tiles[tryRow, tryCol] = "o";
                obstaclesPlaced++;
            }
        }

        return tiles;
    }

    public Vector2 coordFilter(float i, float j)
    {

        return new Vector2((j * 0.32F), -(i * 0.32F));

    }
    
    public void cleanupLevel()
    {

        //GameObject[] enemies;
        //GameObject[] entrance;
        //GameObject[] exit;
        //GameObject[] background;

        // Remove enemy, tileEntrance, tileExit, tileBackground
        
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //entrance = GameObject.FindGameObjectsWithTag("TileEntrance");
        //exit = GameObject.FindGameObjectsWithTag("TileExit");
        //background = GameObject.FindGameObjectsWithTag("TileBackground");

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileEntrance"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileExit"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileBackground"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileWalls"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileInnerWalls"))
        {
            Destroy(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TilePath"))
        {
            Destroy(go);
        }

    }

    public void makeLevelNumber(int levelNumber)
    {

        // walls, floor, path, monsters, and shit

        Debug.Log(levelNumber);

        if (levelNumber > 1)
        {
            cleanupLevel();
        }

        if (levelNumber == 1)
        {

            GameObject[] enemyArray = { Slime };

            renderLevel(39, 39, 3, enemyArray, DeadForestWalls, DeadForestFloor, DeadForestInnerWalls, DeadForestPath);
        }

        if (levelNumber == 2)
        {

            GameObject[] enemyArray = { Slime };

            renderLevel(39, 39, 5, enemyArray, DeadForestWalls, DeadForestFloor, DeadForestInnerWalls, DeadForestPath);

        }


    }

    // Render level tiles and spawn player and monsters

    public void renderLevel(int rows, int cols, int enemyNum, GameObject[] enemyTypes, GameObject[] walls, GameObject[] floor, GameObject[] innerWalls, GameObject[] path)
    {
        string[,] levelMatrix = levelBaseGenerator(rows, cols, enemyNum);

        int levelRows = levelMatrix.GetLength(0);
        int levelCols = levelMatrix.GetLength(1);

        for (var i = 0; i < levelRows; i++)
        {
            for (var j = 0; j < levelCols; j++)
            {
                // Walls
                if (levelMatrix[i, j] == "w")
                {
                    //Debug.Log("Wall");

                    Instantiate(walls[Random.Range(0, walls.Length - 1)], coordFilter(i, j), Quaternion.identity);

                }


                // "Obstacle" or innerwalls
                if (levelMatrix[i, j] == "o")
                {

                    Instantiate(innerWalls[Random.Range(0, innerWalls.Length - 1)], coordFilter(i, j), Quaternion.identity);

                }

                // "path"
                if (levelMatrix[i, j] == "p")
                {

                    Instantiate(path[Random.Range(0, path.Length - 1)], coordFilter(i, j), Quaternion.identity);

                }

                // empty
                if (levelMatrix[i, j] == " ")
                {

                    Instantiate(floor[Random.Range(0, floor.Length - 1)], coordFilter(i, j), Quaternion.identity);

                }

                // "eXit"
                if (levelMatrix[i, j] == "x")
                {

                    Instantiate(Exit, coordFilter(i, j), Quaternion.identity);

                }

                if (levelMatrix[i, j] == "s")
                {

                    Instantiate(Entrance, coordFilter(i, j), Quaternion.identity);

                }

                if (levelMatrix[i, j] == "M")
                {

                    Instantiate(path[Random.Range(0, path.Length - 1)], coordFilter(i, j), Quaternion.identity);

                    // Instantiate random monster from monsters array

                    Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length - 1)], coordFilter(i, j), Quaternion.identity);

                }

            }
        }

        GameObject player;

        player = GameObject.Find("Player");

        GameObject entrance;

        entrance = GameObject.FindGameObjectWithTag("TileEntrance");

        player.transform.position = entrance.transform.position;

        // This is here because it can be
        Console.WriteLine("Hello!");
    }


    // Use this for initialization
    void Start () {

        Debug.Log("Making level 1");
        makeLevelNumber(1);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
