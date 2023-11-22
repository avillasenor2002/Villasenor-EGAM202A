using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public float speed;


    // Start is called before the first frame update
    void awake()
    {
        this.transform.Rotate(0.0f, Random.RandomRange(0,360), 0.0f, Space.Self);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        this.transform.Rotate(0.0f, speed, 0.0f, Space.Self);
        //speed = speed+Time.deltaTime;
        //this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //xAngle = xAngle + speed;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
