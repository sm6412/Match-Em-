using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    // scale 
    float scaleAmount = 0.8188466f;

    // set the width and height of the grid
    public const int width = 5;
    public const int height = 5;


    // two dimensional array 
    public GameObject[,] tiles;

    // two dimensional array of objects
    private int[,] tileVals;

    // gridholder contains x and y of each element 
    public GameObject[,] gridHolder;

    // holds tile sprite
    public GameObject tilePrefab;

    public List<GameObject> startTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        // instantiates the 2d array 
        tiles = new GameObject[width, height];
        tileVals = new int[width, height];
        gridHolder = new GameObject[width, height];

        // fill grid with animals
        int counter = 0;
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                gridHolder[x, y] = startTiles[counter];
                setNewTile(startTiles[counter].transform.position.x, startTiles[counter].transform.position.y, x, y);
                counter++;
            }
        }

        Destroy(tiles[2,2]);

        // ensure there are no matches in the start board 
        GameManager.Instance.checkGrid();
        
    }

    // creates new tile
    public void setNewTile(float xPos, float yPos, int x, int y)
    {
        GameObject newTile = Instantiate(tilePrefab);

        Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
        newTile.transform.localScale = scale;

        // set the position 
        newTile.transform.localPosition = new Vector2(xPos,yPos);

        tiles[x, y] = newTile;

        Tile tileScript = newTile.GetComponent<Tile>();

        int randomVal = Random.Range(0, 25);
        tileScript.SetSprite(randomVal);

    }

    // return the grid width
    public int getWidth()
    {
        return width;
    }

    // return the grid height
    public int getHeight()
    {
        return height;
    }
}
