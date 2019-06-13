using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazySusan : MonoBehaviour
{
    // public GameObject item_1;
    // public GameObject item_2;
    // private GameObject[] items;
    // int[] array1 = new int[5];
    GameObject[] items = new GameObject[8];
    // Start is called before the first frame update
    private bool isRotating;
    private int rotationCount; 
    void Start()
    {
        Debug.Log("LazySusan.Start: entered");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // cube.transform.position = new Vector3(0, 0.5f, 0);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.0f);
        // cube.transform.position = transform.position;
        // cube.transform.position.z += 5.0f;
        items[0] = cube; 

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z);
        items[1] = sphere; 

        isRotating = false;
        rotationCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationCount > 0) {
            // transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
            foreach (GameObject go in items)
            {
                if (go != null)
                {
                    go.transform.RotateAround(transform.position, Vector3.up, 2.0f);
                    // Debug.Log($"LazySusan.RotateCW: go.pos.x={go.transform.position.x},go.pos.z={go.transform.position.z}");
                }

            }
            rotationCount--;

        }
        
    }

    void RotateCW() {
        // var validItems = items.Where(i => i.Field != null && i.State != ItemStates.Deleted);
        // var validItems = items.Where(i => i != null);
        Debug.Log($"LazySusan.RotateCW: self.pos={transform.position}");
        foreach (GameObject go in items)
        // foreach (GameObject go in validItems)
        {
            if (go != null) {
                Debug.Log($"LazySusan.RotateCW: go.pos.x={go.transform.position.x},go.pos.z={go.transform.position.z}");
            }

        }
        // isRotating = true;
        rotationCount = 45;
    }

    // Event listeners
    public void Rotate() {
        RotateCW();
    }

    public void RotateAbs(float theta) {
        foreach (  GameObject go in items)
        {
            // go.transform.RotateAround(transform.position, Vector3.up, theta);
            // go.transform.Rotate(0, theta, 0, Space.World);
            go.transform.eulerAngles = new Vector3(0, theta, 0);
            
        }
    }
    public void RotateDelta(float deltaTheta) {
        foreach (  GameObject go in items)
        {
            if (go != null) {
                // go.transform.eulerAngles = new Vector3(0, theta, 0);
                go.transform.RotateAround(transform.position, Vector3.up, deltaTheta);
            }
            
        }
    }
}
