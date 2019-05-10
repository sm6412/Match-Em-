using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressController : MonoBehaviour
{

    // the amount the progress controller
    // moves when points earned 
    public float moveAmt;
    
    // determines whether the end of the game is reached
    // when the leaf gets to the top of the progress tracker 
    bool reachedEnd = false;

    // moves leaf up 
    public IEnumerator AdjustProgress(int newScore)
    {
        int addAmt = newScore;
        while(addAmt > 0)
        {
            if ((this.transform.position.y + moveAmt) >= 3.04)
            {
                reachedEnd = true;
                yield break;
            }
            this.transform.position += new Vector3(0, moveAmt, 0);
            addAmt--;
            yield return null;
        }
        yield break;

    }


    private void Update()
    {
        // switches to end scene when the progress 
        // leaf reached the top 
        if (reachedEnd)
        {
            SceneManager.LoadScene("End");

        }
    }


}


