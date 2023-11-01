using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheDangLure : MonoBehaviour
{
    public Transform Lure;
    public Transform Fish;
    public bool goTime;
    private float fishX;
    private float fishZ;
    //public int damping = 2;

    //public Fish[] Fishies;

    // Start is called before the first frame update
    void Awake()
    {
        //Fishies = FindObjectsOfType<Fish>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goTime == true) 
        { 
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(Lure);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        transform.LookAt(Lure, Vector3.left);
        };
    }
}
