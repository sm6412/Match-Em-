using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ref to gridmaker 
    private GridMaker gm;

    // ref to the progress controller 
    private ProgressController pc;

    // display current animal being moused over 
    private DisplayCurrentAnimal currentAnimal;

    // player matrix x and y position
    public int matrixX;
    public int matrixY;


    // bool to determine whether the player can move or not
    public bool canMove = true;


    // particle effects
    public GameObject redGlow;
    public GameObject orangeGlow;
    public GameObject yellowGlow;
    public GameObject greenGlow;

    // bool for what progress particle
    // effect is happening 
    bool isGreen = false;
    bool isYellow = false;
    bool isOrange = false;
    bool isRed = false;
    
    // current particles 
    GameObject currentParticles = null;

    // sound
    public AudioClip moveSound;
    private AudioSource audioSource;

    // get borders
    public GameObject greenBorder;
    public GameObject pinkBorder;
    public GameObject yellowBorder;
    public GameObject redBorder;
    public GameObject orangeBorder;
    public GameObject hardBorder;

    // player hat sprites 
    public Sprite redHat;
    public Sprite greenHat;
    public Sprite yellowHat;
    public Sprite orangeHat;

    // Start is called before the first frame update
    void Start()
    {
        // ref to grid maker 
        gm = GameObject.Find("Grid Maker").GetComponent<GridMaker>();
        pc = GameObject.Find("Progress Arrow").GetComponent<ProgressController>();
        currentAnimal = GameObject.Find("Game Manager").GetComponent<DisplayCurrentAnimal>();
        audioSource = GetComponent<AudioSource>();

        // initialize player position
        this.transform.position = gm.tiles[2,2].transform.position;

        matrixX = 2;
        matrixY = 2;
        gm.tiles[2, 2] = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        checkPosition();
        
        // get the mouse position
        Vector3 mousePos = Input.mousePosition;
        // set the z axis of the mouse
        mousePos.z = 0;

        // grab the mouse pos with regards to the screen
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        // use raycasting to see if the player clicks on a game object
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        // make the game react when a tile is pressed 
        GameObject[] gms = GameObject.FindGameObjectsWithTag("border");
        if (hit && Input.GetMouseButtonDown(0))
        {
            
            if ((matrixY-1>=0) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX, matrixY - 1].transform.position)
            {
                
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX, matrixY + 1);
                    }
                    else
                    {
                        isSelectedEasy(matrixX, matrixY + 1);
                    }
                    
                }
                
                GameManager.Instance.RemoveHintParticles();
                audioSource.PlayOneShot(moveSound);
                switchUp();
            }
            else if ((matrixY+1 <= (gm.getHeight()-1)) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX, matrixY + 1].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX, matrixY + 1);
                    }
                    else
                    {
                        isSelectedEasy(matrixX, matrixY + 1);
                    }
                    
                }
                
                GameManager.Instance.RemoveHintParticles();
                audioSource.PlayOneShot(moveSound);
                switchDown();

            }
            else if ((matrixX + 1 <= (gm.getWidth() - 1)) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX + 1, matrixY].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX + 1, matrixY);
                    }
                    else
                    {
                        isSelectedEasy(matrixX + 1, matrixY);
                    }
                    
                }
                
                GameManager.Instance.RemoveHintParticles();
                audioSource.PlayOneShot(moveSound);
                switchRight();

            }
            else if ((matrixX - 1 >= 0)  && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX - 1, matrixY].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX - 1, matrixY);
                    }
                    else
                    {
                        isSelectedEasy(matrixX - 1, matrixY);
                    }
                    
                }
                
                GameManager.Instance.RemoveHintParticles();
                audioSource.PlayOneShot(moveSound);
                switchLeft();

            }
        }
        else if (hit)
        {
            if ((matrixY - 1 >= 0) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX, matrixY - 1].transform.position)
            {
                // make the tile look selected 
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX, matrixY - 1);

                    }
                    else
                    {
                        isSelectedEasy(matrixX, matrixY - 1);

                    }
                    
                }
                
            }
            else if ((matrixY + 1 <= (gm.getHeight() - 1)) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX, matrixY + 1].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX, matrixY + 1);

                    }
                    else
                    {
                        isSelectedEasy(matrixX, matrixY + 1);

                    }
                    
                }
                

            }
            else if ((matrixX + 1 <= (gm.getWidth() - 1)) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX + 1, matrixY].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX + 1, matrixY);
                    }
                    else
                    {
                        isSelectedEasy(matrixX + 1, matrixY);
                    }
                    
                }
                

            }
            else if ((matrixX - 1 >= 0) && hit.collider.tag == "tile" && hit.collider.transform.position == gm.gridHolder[matrixX - 1, matrixY].transform.position)
            {
                if (gms.Length == 0)
                {
                    if (GameManager.Instance.hard == true)
                    {
                        isSelectedHard(matrixX - 1, matrixY);
                    }
                    else
                    {
                        isSelectedEasy(matrixX - 1, matrixY);
                    }
                    
                }
                

            }

        }
        else
        {
            // destroy thick border when not moused over 
            GameObject[] borderParticlesList = GameObject.FindGameObjectsWithTag("border");
            foreach (GameObject borderParticle in borderParticlesList)
            {
                GameObject.Destroy(borderParticle);
            }
        }
    }

    // display hard game border 
    void isSelectedHard(int x, int y)
    {
        Vector2 pos = gm.gridHolder[x, y].transform.position;
        GameObject currentTile = gm.tiles[x, y];
        Tile currentTileScript = currentTile.GetComponent<Tile>();
        int currentGroup = currentTileScript.group;
        int currentSpecies = currentTileScript.type;
        currentAnimal.DisplaySpecies(currentSpecies, currentTile.GetComponent<SpriteRenderer>().sprite);
        GameObject border = Instantiate(hardBorder);
        Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
        border.transform.localScale = scale;
        border.transform.position = pos;

    }

    // display easy and medium game border
    void isSelectedEasy(int x, int y)
    {
        Vector2 pos = gm.gridHolder[x, y].transform.position;
        GameObject currentTile = gm.tiles[x, y];
        Tile currentTileScript = currentTile.GetComponent<Tile>();
        int currentGroup = currentTileScript.group;
        int currentSpecies = currentTileScript.type;
        currentAnimal.DisplaySpecies(currentSpecies,currentTile.GetComponent<SpriteRenderer>().sprite);

        if (currentGroup==1)
        {
            GameObject border = Instantiate(greenBorder);
            Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
            border.transform.localScale = scale;
            border.transform.position = pos;
        }
        else if (currentGroup == 2)
        {
            GameObject border = Instantiate(pinkBorder);
            Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
            border.transform.localScale = scale;
            border.transform.position = pos;

        }
        else if (currentGroup == 3)
        {
            GameObject border = Instantiate(redBorder);
            Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
            border.transform.localScale = scale;
            border.transform.position = pos;

        }
        else if (currentGroup == 4)
        {
            GameObject border = Instantiate(yellowBorder);
            Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
            border.transform.localScale = scale;
            border.transform.position = pos;

        }
        else if (currentGroup == 5)
        {
            GameObject border = Instantiate(orangeBorder);
            Vector3 scale = new Vector3(gm.scaleAmount, gm.scaleAmount, 1f);
            border.transform.localScale = scale;
            border.transform.position = pos;

        }

    }

    // update player position
    public void updatePlayerPos(int x, int y)
    {

        matrixX = x;
        matrixY = y;

    }


    // switch player with a tile underneath
    void switchDown()
    {
        GameObject tileToSwitch = gm.tiles[matrixX,matrixY+1];
        Vector2 tempPos = tileToSwitch.transform.position;
        int xToCheck = matrixX;
        int yToCheck = matrixY;

        tileToSwitch.transform.localPosition = this.transform.position;
        gm.tiles[matrixX, matrixY] = tileToSwitch;

        matrixY += 1;
        this.transform.localPosition = tempPos;
        gm.tiles[matrixX, matrixY] = this.gameObject;

        GameManager.Instance.switchMatchCheck(xToCheck, yToCheck);
    }

    // switch player with the tile above
    void switchUp()
    {
        GameObject tileToSwitch = gm.tiles[matrixX, matrixY - 1];
        Vector2 tempPos = tileToSwitch.transform.position;
        int xToCheck = matrixX;
        int yToCheck = matrixY;

        tileToSwitch.transform.localPosition = this.transform.position;
        gm.tiles[matrixX, matrixY] = tileToSwitch;

        matrixY -= 1;
        this.transform.localPosition = tempPos;
        gm.tiles[matrixX, matrixY] = this.gameObject;

        // check for matches
        GameManager.Instance.switchMatchCheck(xToCheck,yToCheck);

    }

    // switch player with the tile to the right of it
    void switchRight()
    {
        GameObject tileToSwitch = gm.tiles[matrixX + 1, matrixY];
        Vector2 tempPos = tileToSwitch.transform.position;
        int xToCheck = matrixX;
        int yToCheck = matrixY;

        tileToSwitch.transform.localPosition = this.transform.position;
        gm.tiles[matrixX, matrixY] = tileToSwitch;

        matrixX += 1;
        this.transform.localPosition = tempPos;
        gm.tiles[matrixX, matrixY] = this.gameObject;

        GameManager.Instance.switchMatchCheck(xToCheck, yToCheck);

    }

    // switch player with the tile to the left of it
    void switchLeft()
    {
        GameObject tileToSwitch = gm.tiles[matrixX - 1, matrixY];
        Vector2 tempPos = tileToSwitch.transform.position;
        int xToCheck = matrixX;
        int yToCheck = matrixY;

        tileToSwitch.transform.localPosition = this.transform.position;
        gm.tiles[matrixX, matrixY] = tileToSwitch;

        matrixX -= 1;
        this.transform.localPosition = tempPos;
        gm.tiles[matrixX, matrixY] = this.gameObject;

        GameManager.Instance.switchMatchCheck(xToCheck, yToCheck);

    }



    // turns movement on and off
    public void switchCanMove(bool res)
    {
        canMove = res;
    }

    // change player color according to current grade
    void checkPosition()
    {

        // B range
        // make red
        double pos = pc.transform.position.y;
        if (pos >= -2.27 && pos < -1.34)
        {
            if (isRed == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = redHat;
                isRed = true;
                // add particles 
                currentParticles = Instantiate(redGlow);
            }
        }
        // B+ range
        // make orange
        else if (pos >= -1.34 && pos < 0.2)
        {
            if (isOrange == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = orangeHat;
                isOrange = true;

                // set particles 
                Destroy(currentParticles);
                currentParticles = Instantiate(orangeGlow);
            }


        }
        // A range
        // make yellow
        else if (pos >= 0.2 && pos < 1.77)
        {
            if (isYellow == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = yellowHat;
                isYellow = true;
                // add particles
                Destroy(currentParticles);
                currentParticles = Instantiate(yellowGlow);
            }
        }
        // A+ range
        else if (pos >= 1.77 && pos < 3.04)
        {
            if (isGreen == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = greenHat;
                isGreen = true;
                // add particles
                Destroy(currentParticles);
                currentParticles = Instantiate(greenGlow);

            }

        }
    }

   
}
