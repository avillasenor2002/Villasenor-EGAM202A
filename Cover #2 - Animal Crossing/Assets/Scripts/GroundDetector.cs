using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Renderer debugRend;
    public float raycastLength = 1;
 
    private void OnCollisionEnter (Collision collision)
    {
        debugRend.material.color= Color.red;
    }

    private void OnCollisionStay(Collision collision)
    {
        debugRend.material.color = Color.yellow;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        debugRend.material.color = Color.blue;
    }
}
