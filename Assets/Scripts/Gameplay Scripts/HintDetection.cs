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

    // list of original matches 
    List<List<int>> mainMatches;

    // ref to gridmaker 
    GridMaker gm;

    // matches in x and y axis 
    List<List<int>> matchPosX;
    List<List<int>> matchPosY;

    // additional match 
    List<int> additionalMatch;

    // current animal group 
    int currentGroup;

    // ref to player script 
    PlayerController player;


    private void Start()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
        gm = GameObject.Find("Grid Maker").GetComponent<GridMaker>();
    }

    // begin looking for two adjacent tiles around player 
    public void IdleHint(int playerX, int playerY,int offset)
    {
        if (offset > 5)
        {
            return;
        }
        

        int currentX = playerX - offset;
        int currentY = playerY - offset;
        int endY = playerY + offset;

        // handle left column
        for (int y = currentY; y <= endY; y++)
        {
            if ((currentX >= 0 && currentX < 5) && (y >= 0 && y < 5))
            {
                if (CheckAdjacent(currentX, y))
                {
                    if (MakeMatchesGlow())
                    {
                        return;
                    }
                }

            }
        }

        // handle right column
        currentX = playerX + offset;
        for (int y = currentY; y <= endY; y++)
        {
            if ((currentX >= 0 && currentX < 5) && (y >= 0 && y < 5))
            {
                if (CheckAdjacent(currentX, y))
                {
                    if (MakeMatchesGlow())
                    {
                        return;
                    }
                }

            }
        }

        // handle top row
        currentX = playerX - offset;
        currentY = playerY - offset;
        int endX = playerX + offset;
        for (int x = currentX; x <= endX; x++)
        {
            if ((x >= 0 && x < 5) && (currentY >= 0 && currentY < 5))
            {
                if (CheckAdjacent(x, currentY))
                {
                    if (MakeMatchesGlow())
                    {
                        return;
                    }
                }

            }
        }

        currentY = playerY + offset;
        for (int x = currentX; x <= endX; x++)
        {
            if ((x >= 0 && x < 5) && (currentY >= 0 && currentY < 5))
            {
                if (CheckAdjacent(x, currentY))
                {
                    if (MakeMatchesGlow())
                    {
                        return;
                    }
                    
                }

            }
        }

        // nothing found in current radius, run with greater offset
        IdleHint(playerX, playerY, offset + 1);
    }

    // check for whether the nearby tile is of the same animal group 
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

    // makes sure additional match is of the same group   
    bool additionalMatchCheck(int x, int y)
    {
        GameObject currentTile = gm.tiles[x, y];

        if (currentTile.tag == "player")
        {
            return false;
        }

        Tile tileScript = currentTile.GetComponent<Tile>();
        int group = tileScript.group;

        if (currentGroup == group)
        {
            return true;
        }
        return false;
    }

    // looks for a new match 
    bool checkAdditionalMatch(int playerX, int playerY)
    {
        // get current group
        GameObject currentTile = gm.tiles[playerX, playerY];
        Tile currentTileScript = currentTile.GetComponent<Tile>();
        currentGroup = currentTileScript.group;

        additionalMatch = new List<int>();

        int offset = 1;
        int currentX = playerX - offset;
        int currentY = playerY - offset;
        int endY = playerY + offset;

        // handle left column
        for (int y = currentY; y <= endY; y++)
        {
            if ((currentX >= 0 && currentX < gm.getWidth()) && (y >= 0 && y < gm.getHeight()))
            {

                if (additionalMatchCheck(currentX, y) && checkForNovelty(currentX,y))
                {
                    additionalMatch.Add(currentX);
                    additionalMatch.Add(y);
                    return true;
                }

            }
        }

        // handle right column
        currentX = playerX + offset;
        for (int y = currentY; y <= endY; y++)
        {
            if ((currentX >= 0 && currentX < gm.getWidth()) && (y >= 0 && y < gm.getHeight()))
            {
                if (additionalMatchCheck(currentX, y) && checkForNovelty(currentX,y))
                {
                    additionalMatch.Add(currentX);
                    additionalMatch.Add(y);
                    return true;
                }

            }
        }


        // handle top row
        currentX = playerX - offset;
        currentY = playerY - offset;
        int endX = playerX + offset;
        for (int x = currentX; x <= endX; x++)
        {
            if ((x >= 0 && x < gm.getWidth()) && (currentY >= 0 && currentY < gm.getHeight()))
            {
                if (additionalMatchCheck(x, currentY) && checkForNovelty(x,currentY))
                {
                    additionalMatch.Add(x);
                    additionalMatch.Add(currentY);
                    return true;
                }

            }
        }


        currentY = playerY + offset;
        for (int x = currentX; x <= endX; x++)
        {
            if ((x >= 0 && x < gm.getWidth()) && (currentY >= 0 && currentY < gm.getHeight()))
            {
                if (additionalMatchCheck(x, currentY) && checkForNovelty(x,currentY))
                {
                    additionalMatch.Add(x);
                    additionalMatch.Add(currentY);
                    return true;

                }

            }
        }
        return false;

    }

    // make sure the new match is not already found 
    bool checkForNovelty(int compareX, int compareY)
    {
        for (int x = 0; x < mainMatches.Count; x++)
        {
            List<int> matchedTile = mainMatches[x];
            int row = matchedTile[0];
            int col = matchedTile[1];
            if (compareX==row && compareY == col)
            {
                return false;
            }
        }
        return true;
    }

    // makes the match glow 
    bool MakeMatchesGlow()
    {
        Vector2 pos;
        int counter = 0;
        if (mainMatches.Count < 3)
        {
            for (int x = 0; x < mainMatches.Count; x++)
            {
                List<int> matchedTile = mainMatches[x];
                int row = matchedTile[0];
                int col = matchedTile[1];
                if (checkAdditionalMatch(row, col))
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }
        }

        if (counter == 2)
        {
            return false;
        }
        // lets add the additional match 
        else if(counter < 2 && mainMatches.Count<3)
        {
            mainMatches.Add(additionalMatch);
        }

        for (int x = 0; x < mainMatches.Count; x++)
        {
            List<int> matchedTile = mainMatches[x];
            int row = matchedTile[0];
            int col = matchedTile[1];
            GameObject currentTile = gm.tiles[row, col];
            Tile currentTileScript = currentTile.GetComponent<Tile>();
            int singleGroup = currentTileScript.group;
            if (currentGroup == singleGroup)
            {
                // handle current block
                pos = gm.tiles[row, col].transform.position;

                // emit particles
                HintParticles(pos, currentGroup);

            }



        }
        return true;

    }

    // display hint particles 
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
