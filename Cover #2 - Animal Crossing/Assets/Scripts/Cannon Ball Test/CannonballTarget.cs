using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballTarget : MonoBehaviour
{
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
