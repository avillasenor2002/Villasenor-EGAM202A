using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StarCollect : MonoBehaviour
{
    public Material LiveStar;
    public Material CollectedStar;
    public bool isCollect;
    public bool initCollect;
    public GameObject Object;
    public GameObject Shadow;
    public LineForce player;
    public ParticleSystem system;
    

    // Start is called before the first frame update
    void Awake()
    {
        Object.GetComponent<MeshRenderer>().material = LiveStar;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollect == true)
        {
            Object.GetComponent<MeshRenderer>().material = CollectedStar;
            Shadow.GetComponent<MeshRenderer>().material = CollectedStar;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("Game");
            isCollect = true;

            if (initCollect == false)
            {
                player.starcollect = player.starcollect + 1;
                initCollect= true;
                system.Play();
            }
        }
    }
}
