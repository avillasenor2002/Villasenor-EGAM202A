using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidJump : MonoBehaviour
{
    public Rigidbody rb;

    public float force = 1f;

    public Camera gameCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(screenPosition);

        Vector3 ourPosition  = transform.position;
        //if (Input.GetKeyDown (KeyCode.Space))
        //{
        //rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        //}
        Vector3 ustoMouseDelta = worldPosition - ourPosition;
        ustoMouseDelta.z = 0;

        ustoMouseDelta.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(ustoMouseDelta.normalized * force, ForceMode.Impulse);
        }

        Debug.DrawLine(worldPosition, ourPosition);
        Debug.DrawRay (ourPosition, ustoMouseDelta, Color.red);
    }
}
