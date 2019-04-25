using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // this script does not destroy the target object
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(this.tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
