using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject currentstage;
    public GameObject nextstage;
    public bool ishoney;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "AsteroidR")
        {
            currentstage.SetActive(false);
            nextstage.SetActive(true);
        }
    }
}