using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpScript : MonoBehaviour
{
    public ParticleSystem system;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
                system.Play();
        }
    }
}
