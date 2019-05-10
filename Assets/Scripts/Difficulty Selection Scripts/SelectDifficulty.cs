using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    // original button scale 
    float originalScale;

    // different difficulty buttons 
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;

    // ref to audio source 
    private AudioSource audioSource;

    // sound effects for when the players makes a match
    public AudioClip mouseOver;

    bool overOption= false;

    // Start is called before the first frame update
    void Start()
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
               // easy button clicked 
            if (hit.collider.tag == "easy button")
            {
                // switch scene to gameplay
                SceneManager.LoadScene("Easy Level");
            }
            // medium button clicked 
            else if (hit.collider.tag == "medium button")
            {
                // switch scene to gameplay
                SceneManager.LoadScene("Medium Level");
            }
            // hard level clicked 
            else if (hit.collider.tag == "hard button")
            {
                // switch scene to gameplay
                SceneManager.LoadScene("Hard Level");
            }
        }
        // detect if moused over buttons 
        else if (hit)
        {
            if (hit.collider.tag == "easy button")
            {
                if(overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                easyButton.transform.localScale = scale;
            }
            else if (hit.collider.tag == "medium button")
            {
                if (overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                mediumButton.transform.localScale = scale;
            }
            else if (hit.collider.tag == "hard button")
            {
                if (overOption == false)
                {
                    audioSource.PlayOneShot(mouseOver);
                    overOption = true;
                }
                float scaleAmount = 52.335f;
                Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
                hardButton.transform.localScale = scale;
            }
        }
        else
        {
            // reset scale when nothing is being moused over 
            float scaleAmount = originalScale;
            Vector3 scale = new Vector3(scaleAmount, scaleAmount, 1f);
            easyButton.transform.localScale = scale;
            mediumButton.transform.localScale = scale;
            hardButton.transform.localScale = scale;
            overOption = false;
  

        }

    }
}
