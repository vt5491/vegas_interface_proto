using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.Find("EventSystem");
        Debug.Log($"TmpBehavior.Start: go={go}");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
