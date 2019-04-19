using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // animal sprites
    [Header("Amphibian Sprites")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    [Header("Bird Sprites")]
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;

    [Header("Mammal Sprites")]
    public Sprite sprite11;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;
    public Sprite sprite15;

    [Header("Reptiles Sprites")]
    public Sprite sprite16;
    public Sprite sprite17;
    public Sprite sprite18;
    public Sprite sprite19;
    public Sprite sprite20;

    [Header("Fish Sprites")]
    public Sprite sprite21;
    public Sprite sprite22;
    public Sprite sprite23;
    public Sprite sprite24;
    public Sprite sprite25;
    
    // animal species
    public int type;
    // animal group
    public int group;

    // set tile animal group and species 
    public void SetSprite(int rand)
    {
        type = rand;
        if (type == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
            group = 1;
        }
        else if (type == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
            group = 1;
        }
        else if (type == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite3;
            group = 1;
        }
        else if (type == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprite4;
            group = 1;
        }
        else if (type == 4)
        {
            GetComponent<SpriteRenderer>().sprite = sprite5;
            group = 1;
        }

        // next animal group 
        else if (type == 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprite6;
            group = 2;
        }
        else if (type == 6)
        {
            GetComponent<SpriteRenderer>().sprite = sprite7;
            group = 2;
        }
        else if (type == 7)
        {
            GetComponent<SpriteRenderer>().sprite = sprite8;
            group = 2;
        }
        else if (type == 8)
        {
            GetComponent<SpriteRenderer>().sprite = sprite9;
            group = 2;
        }
        else if (type == 9)
        {
            GetComponent<SpriteRenderer>().sprite = sprite10;
            group = 2;
        }

        // next animal group
        else if (type == 10)
        {
            GetComponent<SpriteRenderer>().sprite = sprite11;
            group = 3;
        }
        else if (type == 11)
        {
            GetComponent<SpriteRenderer>().sprite = sprite12;
            group = 3;
        }
        else if (type == 12)
        {
            GetComponent<SpriteRenderer>().sprite = sprite13;
            group = 3;
        }
        else if (type == 13)
        {
            GetComponent<SpriteRenderer>().sprite = sprite14;
            group = 3;
        }
        else if (type == 14)
        {
            GetComponent<SpriteRenderer>().sprite = sprite15;
            group = 3;
        }

        // next animal group
        else if (type == 15)
        {
            GetComponent<SpriteRenderer>().sprite = sprite16;
            group = 4;
        }
        else if (type == 16)
        {
            GetComponent<SpriteRenderer>().sprite = sprite17;
            group = 4;
        }
        else if (type == 17)
        {
            GetComponent<SpriteRenderer>().sprite = sprite18;
            group = 4;
        }
        else if (type == 18)
        {
            GetComponent<SpriteRenderer>().sprite = sprite19;
            group = 4;
        }
        else if (type == 19)
        {
            GetComponent<SpriteRenderer>().sprite = sprite20;
            group = 4;
        }

        // last animal group
        else if (type == 20)
        {
            GetComponent<SpriteRenderer>().sprite = sprite21;
            group = 5;
        }
        else if (type == 21)
        {
            GetComponent<SpriteRenderer>().sprite = sprite22;
            group = 5;
        }
        else if (type == 22)
        {
            GetComponent<SpriteRenderer>().sprite = sprite23;
            group = 5;
        }
        else if (type == 23)
        {
            GetComponent<SpriteRenderer>().sprite = sprite24;
            group = 5;
        }
        else if (type == 24)
        {
            GetComponent<SpriteRenderer>().sprite = sprite25;
            group = 5;
        }



    }


}
