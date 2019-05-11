using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create script that allows you to exit the game at any point
public class ExitController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
