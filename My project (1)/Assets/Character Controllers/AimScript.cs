using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseScreenPos = Input.mousePosition;
        var startingScreenPos = mainCamera.WorldToScreenPoint(this.transform.position);
        mouseScreenPos.x -= startingScreenPos.x;
        mouseScreenPos.y -= startingScreenPos.y;
        var angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
