using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{

    public Camera gameCamera;
    public float launchStrength;
    public LaunchObject launchPrefab;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 screenPosition =Input.mousePosition;
            Ray worldRay = gameCamera.ScreenPointToRay(screenPosition);

            LaunchObject newLaunchedObject= Instantiate<LaunchObject>(launchPrefab);
            newLaunchedObject.transform.position = worldRay.origin;
            newLaunchedObject.Launch(worldRay.direction * launchStrength);

        }
    }
}
