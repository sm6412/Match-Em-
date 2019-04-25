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


    public IEnumerator AdjustProgress(int newScore)
    {
        int addAmt = newScore;
        while(addAmt > 0)
        {
            if ((this.transform.position.y + moveAmt) >= 3.11)
            {
                yield break;
            }
            this.transform.position += new Vector3(0, moveAmt, 0);
            currentY = this.transform.position.y;
            addAmt--;
            yield return null;
        }
        yield break;

    }


}
