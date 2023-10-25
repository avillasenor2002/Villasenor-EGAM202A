using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    //public float lowspeed;
    //public PlayerController scorescript;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
