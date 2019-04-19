using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    // initial score
    int score = 0;
    // the amount the progress controller
    // moves
    public float moveAmt;
    // current y position of progress arrow
    public static float currentY;

    private void Awake()
    {
        // set pos
        currentY = this.transform.position.y;
    }

    public void Update()
    {
        // if points gained, move up progress arrow
        if (score != 0 && (this.transform.position.y+moveAmt) < 3.11)
        {
            this.transform.position += new Vector3(0, moveAmt, 0);
            currentY = this.transform.position.y;
            score--; 

        }
    }

    // when new points gained, add it to the score
    public void AdjustProgress(int newScore)
    {
        score = newScore;
    }


}
