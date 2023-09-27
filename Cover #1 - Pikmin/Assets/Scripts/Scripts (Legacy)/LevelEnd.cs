using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject currentstage;
    public GameObject nextstage;
    public GameObject Victory;
    public GameObject MscLvl1;
    public GameObject MscLvl2;
    public bool ishoney;
    public bool final;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ishoney == true)
        {
            gameObject.layer = 9;
        }

        if (ishoney == false)
        {
            gameObject.layer = 10;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ishoney = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            ishoney = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "PlayerA")
        {
            currentstage.SetActive(false);
            nextstage.SetActive(true);
            if (final == true)
            {
                MscLvl1.SetActive(false);
                MscLvl2.SetActive(false);
                Victory.SetActive(true);
            }
        }
    }
}
