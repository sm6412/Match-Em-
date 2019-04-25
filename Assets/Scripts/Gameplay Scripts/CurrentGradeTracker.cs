using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGradeTracker : MonoBehaviour
{
    // keeps track of current grade
    public string currentGrade = "";

    // adjusts grade when it is increased
    public void setCurrentGrade(string grade)
    {
        currentGrade = grade;
    }
}
