using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressController : MonoBehaviour
{
    // initial score

    // the amount the progress controller
    // moves
    public float moveAmt;
    // current y position of progress arrow
    bool reachedEnd = false;




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
        if (reachedEnd)
        {
            SceneManager.LoadScene("End");

        }
    }


}


