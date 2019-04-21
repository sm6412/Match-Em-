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

    // player matrix x and y position
    int matrixX;
    int matrixY;

    // amount of moves player can make
    public int moveNum;

    // ref to text that displays moves 
    public TextMesh moves;

    // bool to determine whether the player can move or not
    public bool canMove = true;

    // ref to current grade tracker 
    CurrentGradeTracker gradeTracker;

    // particle effects
    public GameObject redGlow;
    public GameObject orangeGlow;
    public GameObject yellowGlow;
    public GameObject greenGlow;

    bool isGreen = false;
    bool isYellow = false;
    bool isOrange = false;
    bool isRed = false;
    GameObject currentParticles = null;


    // Start is called before the first frame update
    void Start()
    {
        // ref to grid maker 
        gm = GameObject.Find("Grid Maker").GetComponent<GridMaker>();
        pc = GameObject.Find("Progress Arrow").GetComponent<ProgressController>();
        gradeTracker = GameObject.Find("Current Grade").GetComponent<CurrentGradeTracker>();

        // initialize player position
        this.transform.position = gm.tiles[2,2].transform.position;

        matrixX = 2;
        matrixY = 2;
        gm.tiles[2, 2] = this.gameObject;
        moves.text = moveNum.ToString();
  
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();
        // move player and determine switches
        if (canMove==true && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && ((matrixY+1)<gm.getHeight()))
        {
            moveNum--;
            moves.text = moveNum.ToString();
            switchDown();


        }
        else if (canMove==true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && ((matrixY - 1) >= 0))
        {
            moveNum--;
            moves.text = moveNum.ToString();
            switchUp();

        }
        else if (canMove == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && ((matrixX + 1) < gm.getWidth()))
        {
            moveNum--;
            moves.text = moveNum.ToString();
            switchRight();

        }
        else if (canMove == true && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && ((matrixX - 1) >= 0))
        {
            moveNum--;
            moves.text = moveNum.ToString();
            switchLeft();

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
        string greenString = "#56FF00";
        string yellowString = "#FFFF01";
        string orangeString = "#FFAA01";
        string redString = "#FE0003";

        // B range
        // make red
        double pos = pc.transform.position.y;
        if (pos >= -2.1 && pos < -1.19)
        {
            if (isRed == false)
            {
                Color newColor;
                ColorUtility.TryParseHtmlString(redString, out newColor);
                this.GetComponent<SpriteRenderer>().color = newColor;
                gradeTracker.setCurrentGrade("B");
                isRed = true;
                // add particles 
                currentParticles = Instantiate(redGlow);
            }
        }
        // B+ range
        // make orange
        else if (pos >= -1.19 && pos < 0.4)
        {
            if (isOrange == false)
            {
                Color newColor;
                ColorUtility.TryParseHtmlString(orangeString, out newColor);
                this.GetComponent<SpriteRenderer>().color = newColor;
                gradeTracker.setCurrentGrade("B+");
                isOrange = true;

                // set particles 
                Destroy(currentParticles);
                currentParticles = Instantiate(orangeGlow);
            }


        }
        // A range
        // make yellow
        else if (pos >= 0.4 && pos < 1.87)
        {
            if (isYellow == false)
            {
                Color newColor;
                ColorUtility.TryParseHtmlString(yellowString, out newColor);
                this.GetComponent<SpriteRenderer>().color = newColor;
                gradeTracker.setCurrentGrade("A");
                isYellow = true;
                // add particles
                Destroy(currentParticles);
                currentParticles = Instantiate(yellowGlow);
            }
        }
        // A+ range
        else if (pos >= 1.87 && pos < 3.11)
        {
            if (isRed == false)
            {
                Color newColor;
                ColorUtility.TryParseHtmlString(greenString, out newColor);
                this.GetComponent<SpriteRenderer>().color = newColor;
                gradeTracker.setCurrentGrade("A+");
                isRed = true;
                // add particles
                Destroy(currentParticles);
                currentParticles = Instantiate(redGlow);

            }

        }
    }
}
