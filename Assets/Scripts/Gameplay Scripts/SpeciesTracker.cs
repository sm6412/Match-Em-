using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesTracker : MonoBehaviour
{
    // array that holds how many of each species 
    // was matched
    public int[] numOfEachSpeciesOverWholeGame;

    // int that has the position that corresponds with
    // the most matched species 
    public static int mostSpecies;

    // Start is called before the first frame update
    void Start()
    {
        mostSpecies = 0;
        
        // instantiate the species matched the most in the game
        numOfEachSpeciesOverWholeGame = new int[25];
        for (int i = 0; i < 25; i++)
        {
            numOfEachSpeciesOverWholeGame[i] = 0;
        }

    }

    // increment the count for how many of that species is matched 
    public void updateSpecies(int pos)
    {
        numOfEachSpeciesOverWholeGame[pos]++;
        MostSpecies();
    }

    // discover which species had the most matches 
    public void MostSpecies()
    {
        int maxSpecies = numOfEachSpeciesOverWholeGame[0];
        int maxPos = 0;
        for (int i = 1; i < 25; i++)
        {
            int currentSpecies = numOfEachSpeciesOverWholeGame[i];
            if (currentSpecies > maxSpecies)
            {
                maxSpecies = currentSpecies;
                maxPos = i;
            }

        }
        mostSpecies= maxPos;
       

    }


}
