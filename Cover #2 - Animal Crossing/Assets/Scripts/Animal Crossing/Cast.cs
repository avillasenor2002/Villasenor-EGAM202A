using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Fish;

public class Cast : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public bool canJump;
    bool statechange;
    public bool lureUp;
    public bool lureDown;
    public bool lureFinal;
    public Fish fish;
    public Fish fish2;
    public Fish fish3;
    public GameObject text;
    public GameObject Particle;
    public GameObject SmallParticle;
    public RapidEnd End;
    public FaceTheDangLure FishRotate;
    public FaceTheDangLure FishRotate2;
    public FaceTheDangLure FishRotate3;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            //its jumpin time
            rb.AddForce(Vector3.back * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            text.SetActive(false);
        }

        if (lureUp == true && lureDown == false && lureFinal == false)
        {
            this.transform.position = new Vector3(-0.56f, 0.24f, -9.82001f);
        }
        if (lureUp == false && lureDown == true && lureFinal == false)
        {
            this.transform.position = new Vector3(-0.56f, 0.13f, -9.82001f);
        }
        else if (lureUp == false && lureDown == false && lureFinal == true)
        {
            this.transform.position = new Vector3(-0.56f, -0.1700001f, -9.82001f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fishing" & statechange == false)
        {
            statechange = true;
            lureUp = true;
            fish.currentState = TreasureState.Moving;
            fish2.currentState = TreasureState.Moving;
            fish3.currentState = TreasureState.Moving;
            End.starting = false;
            FishRotate.goTime = true;
            FishRotate2.goTime = true;
            FishRotate3.goTime = true;
        }
    }
}
