using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LaunchObject3: MonoBehaviour
{
    //public Rigidbody rb;

    public float duration;

    public GameObject Block;
    public GameObject Sphere;
    public GameObject Capsule;
    public Finished launchPrefab;

    //public float readyToDeleteDuration = 0.1f;
    public bool isClicked;
    public bool goTime;
    public enum BlockShape
    {
        Block,
        Sphere,
        Capsle
    }
    public BlockShape shape;

    public void Launch(Vector3 force)
    {
        //rb.AddForce(force, ForceMode.Impulse);
    }

    void Start()
    {
        StartCoroutine(Roll());
        isClicked = false;
        goTime = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && goTime == true)
        {
            isClicked = true;
        }
    }

    IEnumerator Roll()
    {
        yield return new WaitForSeconds(duration);

        while (true)
        {
            if (shape == BlockShape.Block && isClicked == false)
            {
                Block.SetActive(false);
                Sphere.SetActive(true);
                shape = BlockShape.Sphere;
            }

            else if (shape == BlockShape.Sphere && isClicked == false)
            {
                Sphere.SetActive(false);
                Capsule.SetActive(true);
                shape = BlockShape.Capsle;
            }

            else if (shape == BlockShape.Capsle && isClicked == false)
            {
                Capsule.SetActive(false);
                Block.SetActive(true);
                shape = BlockShape.Block;
            }

            if (isClicked == true)
            {
                launchPrefab.goTime = true;
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(duration);
        }
        //yield return new WaitForSeconds(readyToDeleteDuration);

        //Destroy(this.gameObject);
    }
}
