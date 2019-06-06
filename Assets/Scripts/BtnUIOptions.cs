using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUIOptions : MonoBehaviour
{
    GameObject lsGo;
    private LazySusan ls;

    void Start() {
        ls = GameObject.Find("LazySusan").GetComponent<LazySusan>();
        lsGo = GameObject.Find("LazySusan");
    }
    public void doIt()
    {
        Debug.Log("BtnUIOptions.doIt: entered");
    }

    public void rotateLS() 
    {
        // ls.RotateCW();
        // ls.SendMessage("Rotate");
        lsGo.SendMessage("Rotate");

    }
}
