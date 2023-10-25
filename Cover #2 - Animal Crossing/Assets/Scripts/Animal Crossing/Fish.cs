using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static RapidEnd;

public class Fish : MonoBehaviour
{
    // Navigation
    public NavMeshAgent agent;
    public Cast cast;
    public RapidEnd end;

    // Treasure state
    public TreasureState currentState;
    public enum TreasureState
    {
        Idle,
        Moving,
        Finished
    }

    // Moving variables
    public Transform lurePosition;
    public Transform markerPosition;
    public bool statechange;
    public int finalbite;
    // Alternate solution
    //public Transform sphereVisual;
    //public float sphereRadius = 1f;

    void Update()
    {
        switch (currentState)
        {
            case TreasureState.Idle:
                UpdateIdle();
                break;
            case TreasureState.Moving:
                UpdateMoving();
                break;
            case TreasureState.Finished:
                UpdateMoving();
                break;
        }
    }

    void UpdateIdle()
    {
        agent.isStopped = true;

        // Alternate solution
        //Vector3 position = transform.position;
        //Ray ray = new(position + Vector3.up * 10, Vector3.down);

        //// Dbeug viduals
        //sphereVisual.transform.position = position;
        //sphereVisual.transform.localScale = new Vector3(sphereRadius, 20f, sphereRadius);

        //int characterCount = 0;

        //RaycastHit[] hits = Physics.SphereCastAll(ray, sphereRadius, 20f);
        //foreach (RaycastHit hit in hits)
        //{
        //    ClickCharacter character = hit.transform.GetComponent<ClickCharacter>();
        //    if (character != null)
        //    {
        //        characterCount++;
        //    }
        //}

        //Debug.Log(characterCount);
    }

    void UpdateMoving()
    {
        agent.isStopped = false;

        if (statechange == true && finalbite > 0)
        {
            agent.SetDestination(markerPosition.position);
        }
        else if (statechange == false && finalbite > 0) 
        {
            agent.SetDestination(lurePosition.position);
        }
        else if (statechange == true && finalbite <= 0)
        {
            currentState = TreasureState.Finished;
        }
    }

    void UpdateFinished()
    {
        agent.isStopped = false;
        agent.SetDestination(lurePosition.position);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lure")
        {
            statechange = true;
            finalbite = finalbite - Random.Range(1, 4);
            cast.lureUp = false;
            cast.lureDown = true;
            if (finalbite <= 0)
            {
                cast.Particle.SetActive(true);
                end.currentState = ClickState.Action;
            }
            else
            {
                cast.SmallParticle.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "Base")
        {
            statechange = false;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Lure")
        {
            cast.lureUp = true;
            cast.lureDown = false;
            cast.SmallParticle.SetActive(false);
        }
    }
}
