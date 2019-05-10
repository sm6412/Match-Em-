using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    float originalScale;
   
    // ref to audio source
    private AudioSource audioSource;
    bool overOption = false;

    // play and instructions buttons 
    public GameObject play;
    public GameObject instruc;

    // sound effects for when the players makes a match
    public AudioClip mouseOver;
    private void Start()
    {
        originalScale = 45;
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        // get the mouse position
        Vector3 mousePos = Input.mousePosition;
        // set the z axis of the mouse
        mousePos.z = 0;

        // grab the mouse pos with regards to the screen
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        // use raycasting to see if the player clicks on a game object
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (hit && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "start button")
            {
                // switch to difficulty selection scene
                SceneManager.LoadScene("Difficulty Selection");
            }
            if (hit.collider.tag == "instructions button")
            {
                // switch scene to instructions scene 
                SceneManager.LoadScene("Instructions 1");
            }
        }
        else if (hit)
        {
            // see whether moused over 
            if (hit.collider.tag == "start button")
            {
                if (overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                play.transform.localScale = scale;
            }
            if (hit.collider.tag == "instructions button")
            {
                if (overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                instruc.transform.localScale = scale;
            }
        }
        else
        {
            float scaleAmount = originalScale;
            Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
            instruc.transform.localScale = scale;
            play.transform.localScale = scale;
            overOption = false;

        }

    }
}
