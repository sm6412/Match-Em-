using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentAnimal : MonoBehaviour
{
    // current animal sprite 
    public SpriteRenderer speciesSR;

    // most matched species name text
    public Text speciesNameText;

    public void DisplaySpecies(int type, Sprite sprite)
    {
        // AMPHIBIANS 
        if (type == 0)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "American\nBullfrog";

        }
        else if (type == 1)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Eastern Red\nSpotted Newt";
        }
        else if (type == 2)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Mexican\nAxolotl";
        }
        else if (type == 3)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Spotted\nSala-\nmander";
        }
        else if (type == 4)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Tree\nFrog";
        }

        // BIRDS 
        else if (type == 5)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Emperor\nPenguin";
        }
        else if (type == 6)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Flamingo";
        }
        else if (type == 7)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Macaw";
        }
        else if (type == 8)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Ostrich";
        }
        else if (type == 9)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Snowy\nOwl";

        }

        // MAMMALS
        else if (type == 10)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Cat";
        }
        else if (type == 11)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Fruit\nBat";
        }
        else if (type == 12)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Human";
        }
        else if (type == 13)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Narwhal";
        }
        else if (type == 14)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Platypus";
        }

        // REPTILES
        else if (type == 15)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Alli-\ngator";
        }
        else if (type == 16)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Chameleon";
        }
        else if (type == 17)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Corn\nSnake";
        }
        else if (type == 18)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Iguana";
        }
        else if (type == 19)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Sea\nTurtle";
        }

        // FISH
        else if (type == 20)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Clown-\nfish";
        }
        else if (type == 21)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Manta\nRay";
        }
        else if (type == 22)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Moray\nEel";
        }
        else if (type == 23)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Stone-\nfish";
        }
        else if (type == 24)
        {
            speciesSR.sprite = sprite;
            speciesNameText.text = "Whale\nShark";
        }

    }
}
