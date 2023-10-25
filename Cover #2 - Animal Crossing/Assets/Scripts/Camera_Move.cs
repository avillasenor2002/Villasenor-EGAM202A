using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public float ZPos;
    public float CameraMoveSpeed;
    public GameObject MoveCamera;

    // Update is called once per frame
    void Update()
    {
        ZPos = this.transform.position.z;
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
            //this.transform.position.z = CameraMoveSpeed
        //};
    }
}
