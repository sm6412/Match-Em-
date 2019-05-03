using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDetection : MonoBehaviour
{
    // hint particles 
    public GameObject hintGreenParticles;
    public GameObject hintPinkParticles;
    public GameObject hintRedParticles;
    public GameObject hintYellowParticles;
    public GameObject hintOrangeParticles;

    List<List<int>> mainMatches;
    GridMaker gm;
    List<List<int>> matchPosX;
    List<List<int>> matchPosY;
    int currentGroup;

    private void Start()
    {
        gm = GameObject.Find("Grid Maker").GetComponent<GridMaker>();
    }

    public void IdleHint()
    {
        bool foundMatch = false;
        for (int i = 0; i < gm.getWidth(); i++)
        {
            if (foundMatch == true)
            {
                break;
            }
            for (int j = 0; j < gm.getHeight(); j++)
            {
                if (CheckAdjacent(i, j))
                {
                    MakeMatchesGlow();
                    foundMatch = true;
                    break;
                }
            }
        }

    }

    bool CheckAdjacent(int x, int y)
    {
        matchPosX = new List<List<int>>();
        matchPosY = new List<List<int>>();
        mainMatches = new List<List<int>>();

        // currrent tile info
        GameObject currentTile = gm.tiles[x, y];
        if (currentTile.tag == "player")
        {
            return false;
        }

        Tile currentTileScript = currentTile.GetComponent<Tile>();
        currentGroup = currentTileScript.group;

        // check left tiles
        if ((x != (gm.getWidth() - 1)))
        {
            for (int i = x + 1; i < gm.getWidth(); i++)
            {
                string result = checkMatch(i, y, "x");
                if (result == "break")
                {
                    break;
                }
            }
        }


        // check right tiles 
        if ((x != 0))
        {
            for (int i = x - 1; i >= 0; i--)
            {
                string result = checkMatch(i, y, "x");
                if (result == "break")
                {
                    break;
                }
            }
        }

        // check bottom tiles 
        if ((y != (gm.getHeight() - 1)))
        {
            for (int i = y + 1; i < gm.getHeight(); i++)
            {
                string result = checkMatch(x, i, "y");
                if (result == "break")
                {
                    break;
                }
            }
        }

        // check top tiles 
        if ((y != 0))
        {
            for (int i = y - 1; i >= 0; i--)
            {
                string result = checkMatch(x, i, "y");
                if (result == "break")
                {
                    break;
                }
            }
        }

        // found adjacent matches 
        if (matchPosX.Count >= 1 || matchPosY.Count >= 1)
        {
            // add main animal to matches
            List<int> mainAnimal = new List<int>();
            int row = x;
            int col = y;
            mainAnimal.Add(row);
            mainAnimal.Add(col);
            mainMatches.Add(mainAnimal);

            // add x axis matches
            if (matchPosX.Count > 0)
            {
                
                for (int i = 0; i < matchPosX.Count; i++)
                {
                    
                    List<int> matchedTile = matchPosX[i];
                    row = matchedTile[0];
                    col = matchedTile[1];

                    List<int> matchAnimal = new List<int>();
                    matchAnimal.Add(row);
                    matchAnimal.Add(col);
                    mainMatches.Add(matchAnimal);

                }
               

            }

            // add y axis matches 
            if (matchPosY.Count > 0)
            {
                
                // make tiles of the same animal group glow
                for (int i = 0; i < matchPosY.Count; i++)
                {
                    
                    List<int> matchedTile = matchPosY[i];
                    row = matchedTile[0];
                    col = matchedTile[1];

                    List<int> matchAnimal = new List<int>();
                    matchAnimal.Add(row);
                    matchAnimal.Add(col);
                    mainMatches.Add(matchAnimal);

                }
                

            }
            // return true since match found
            return true;
        }

        return false;

    }

    // checks for when a match occurs
    string checkMatch(int x, int y, string axis)
    {
        // check new tile with the switched tile for a match
        List<int> matchColor = new List<int>();
        GameObject newTile = gm.tiles[x, y];

        if (newTile.tag == "player")
        {
            return "break";
        }

        Tile tileScript = newTile.GetComponent<Tile>();
        int group = tileScript.group;

        if (currentGroup == group)
        {
            matchColor.Add(x);
            matchColor.Add(y);
        }
        else
        {
            return "break";
        }

        // put in correct match pos with correct axis 
        if (axis == "x")
        {
            matchPosX.Add(matchColor);
        }
        else
        {
            matchPosY.Add(matchColor);
        }

        return "continue";
    }


    void MakeMatchesGlow()
    {
        Vector2 pos;
        for (int x = 0; x < mainMatches.Count; x++)
        {
            List<int> matchedTile = mainMatches[x];
            int row = matchedTile[0];
            int col = matchedTile[1];
            // handle current block
            pos = gm.tiles[row, col].transform.position;

            // emit particles
            HintParticles(pos, currentGroup);


        }

    }

    void HintParticles(Vector2 pos, int hintColor)
    {
        if (hintColor == 1)
        {
            (Instantiate(hintGreenParticles)).transform.position = pos;

        }
        else if (hintColor == 2)
        {
            (Instantiate(hintPinkParticles)).transform.position = pos;
        }
        else if (hintColor == 3)
        {
            (Instantiate(hintRedParticles)).transform.position = pos;

        }
        else if (hintColor == 4)
        {
            (Instantiate(hintYellowParticles)).transform.position = pos;

        }
        else if (hintColor == 5)
        {
            (Instantiate(hintOrangeParticles)).transform.position = pos;
        }
    }
}
