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
    List<List<int>> additionalMatches;
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
                    // make sure there are other animals of that
                    // same type somewhere else in the matrix 
                    if (otherMatches(i, j))
                    {
                        MakeMatchesGlow(i, j);
                        foundMatch = true;
                        break;

                    }
                }
            }
        }

    }

    bool CheckAdjacent(int x, int y)
    {
        matchPosX = new List<List<int>>();
        matchPosY = new List<List<int>>();

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

        if (matchPosX.Count >= 1 || matchPosY.Count >= 1)
        {
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

    bool otherMatches(int x, int y)
    {
        additionalMatches = new List<List<int>>();
        GameObject currentTile = gm.tiles[x, y];
        Tile currentTileScript = currentTile.GetComponent<Tile>();
        currentGroup = currentTileScript.group;

        for (int i = 0; i < gm.getWidth(); i++)
        {
            for (int j = 0; j < gm.getHeight(); j++)
            {
                GameObject compareTile = gm.tiles[i, j];
                if (compareTile.tag != "player")
                {
                    Tile compareTileScript = compareTile.GetComponent<Tile>();
                    int compareGroup = compareTileScript.group;

                    List<int> currentMatch = new List<int>();
                    if (compareGroup == currentGroup)
                    {
                        currentMatch.Add(i);
                        currentMatch.Add(j);
                        additionalMatches.Add(currentMatch);
                    }

                }
            }
        }

        if (additionalMatches.Count >= 3)
        {
            return true;

        }

        return false;

    }

    void MakeMatchesGlow(int x, int y)
    {
        GameObject mainTile = gm.tiles[x, y];
        Tile mainTileScript = mainTile.GetComponent<Tile>();
        int hintColor = mainTileScript.group;

        Vector2 pos;
        // make tiles of the same animal group glow
        for (int i = 0; i < additionalMatches.Count; i++)
        {
            List<int> currentTile = additionalMatches[i];
            int row = currentTile[0];
            int col = currentTile[1];
            pos = gm.tiles[row, col].transform.position;

            // emit particles
            HintParticles(pos, hintColor);

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
