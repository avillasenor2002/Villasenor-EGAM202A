using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    public bool goTime;
    public bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        goTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && goTime == true)
        {
            isClicked = true;
        }
        if (isClicked == true && goTime == true) 
        {
            SceneManager.LoadScene("Slots");
        }
    }
}
