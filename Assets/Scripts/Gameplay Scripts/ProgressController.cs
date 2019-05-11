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
    public IEnumerator AdjustProgress(int newScore)
    {
        int addAmt = newScore;
        float currentY = this.transform.position.y;
        float check = (addAmt * moveAmt) + currentY;
        // only play a sound when the game will not end 
        if (GameManager.Instance.recheckingGrid == false && check < 2.98)
        {
            GameManager.Instance.audioSource.PlayOneShot(GameManager.Instance.successSound);
        }
        
        while(addAmt > 0)
        {
            if ((this.transform.position.y + moveAmt) >= 2.98)
            {
                SceneManager.LoadScene("End");
                yield break;
            }
            this.transform.position += new Vector3(0, moveAmt, 0);
            addAmt--;
            yield return null;
        }
        yield break;

    }





}


