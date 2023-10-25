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
    public Fish fish;
    public GameObject text;
    public GameObject Particle;
    public GameObject SmallParticle;
    public RapidEnd End;

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

        if (lureUp == true && lureDown == false)
        {
            this.transform.position = new Vector3(-0.56f, 0.24f, -9.82001f);
        }
        else if (lureUp == false && lureDown == true)
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
            End.starting = false;
        }
    }
}
