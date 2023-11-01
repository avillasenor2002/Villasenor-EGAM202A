using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static RapidEnd;
using static UnityEngine.CullingGroup;

public class Cannonball : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    public void Launch(Vector3 direction, float strength)
    {
        rb.AddForce(direction * strength, ForceMode.Impulse);
    }
}
