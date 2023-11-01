using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnscipt : MonoBehaviour
{
    public GameObject Sardine;
    public GameObject SeaBass;
    public GameObject Shark;
    public GameObject SardineCap;
    public GameObject SeaBassCap;
    public GameObject SharkCap;
    public int fishSpwn;
    public bool fishytime;

    // Start is called before the first frame update
    void Start()
    {
        fishSpwn = Random.Range(0, 9);
        fishytime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fishSpwn <= 3 && fishytime == true)
        {
            Sardine.SetActive(true);
            SardineCap.SetActive(true);
            fishytime = false;
        }
        else if (fishSpwn > 3 && fishSpwn <= 6 && fishytime == true)
        {
            SeaBass.SetActive(true);
            SeaBassCap.SetActive(true);
            fishytime = false;
        }
        else if (fishSpwn > 6 && fishytime == true)
        {
            Shark.SetActive(true);
            SharkCap.SetActive(true);
            fishytime = false;
        }
    }
}
