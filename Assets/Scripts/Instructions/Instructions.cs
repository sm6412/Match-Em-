using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{

    float originalScale;
    
    // ref to audio source
    private AudioSource audioSource;
    bool overOption = false;

    // instruction scenes 
    public bool instruc1;
    public bool instruc2;
    public bool instruc3;
    public bool instruc4;


    // sound effects for when the players makes a match
    public AudioClip mouseOver;
    private void Start()
    {
        originalScale = this.transform.localScale.x;
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
            // switch to next instruction scene when 'next' button pressed 
            if (hit.collider.tag == "next button")
            {
                if (instruc1 == true)
                {
                    SceneManager.LoadScene("Instructions 2");
                }
                else if (instruc2 == true)
                {
                    SceneManager.LoadScene("Instructions 3");
                }
                else if (instruc3 == true)
                {
                    SceneManager.LoadScene("Instructions 4");
                }
                else if (instruc4 == true)
                {
                    SceneManager.LoadScene("Start");
                }
            }
        }
        else if (hit)
        {
            if (hit.collider.tag == "next button")
            {
                if (overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                this.transform.localScale = scale;
            }
        }
        else
        {
            float scaleAmount = originalScale;
            Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
            this.transform.localScale = scale;
            overOption = false;

        }

    }
}

