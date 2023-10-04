using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateBasedCharacter : MonoBehaviour
{
    // List of possible states
    public enum States
    {
        Idle,
        Carry,
        Follow,
    }

    public States currentState;

    // List of possile colors
    public enum Colors
    {
        Red,
        Yellow,
        Blue
    }

    public Colors currentColor;

    // Reference to our nav mesh agent
    public NavMeshAgent agent;

    // Follow variables
    public Vector3 followPosition;

    // Patrol variables
    public List<Vector3> patrolPositions;
    public int patrolIndex;

    public float patrolMinDistance = 1f;

    // Random variables
    public float randomMin = -1f;
    public float randomMax = 1f;

    public float randomCountdown = 2f;
    public float randomTimer = 0;
    public Camera gameCamera;
    // Colorinf
    public Renderer colorRenderer;
    public GameObject indicator;

    void Start()
    {
        // On start, update the color
        switch (currentColor)
        {
            case Colors.Red:
                colorRenderer.material.color = Color.red;
                break;
            case Colors.Yellow:
                colorRenderer.material.color = Color.yellow;
                break;
            case Colors.Blue:
                colorRenderer.material.color = Color.blue;
                break;
        }
    }

    void Update()
    {
        // The update is broken down by each enum value
        switch (currentState)
        {
            case States.Idle:
                UpdateIdle();
                break;
            case States.Carry:
                UpdateCarry();
                break;
            case States.Follow:
                UpdateFollow();
                break;
        }

        indicator.transform.position = agent.transform.position;
    }

    void UpdateIdle()
    {
        agent.isStopped = true;
        indicator.SetActive(false);
    }

    void UpdateFollow()
    {
        agent.isStopped = false;
        indicator.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            // Mouse to world position
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            // Hit anything?
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                // Make the agent go to the collision point
                agent.SetDestination(hitInfo.point);
                //selector.SetDestination(hitInfo.point);
            }
        }
    }

    void UpdateCarry()
    {
        agent.isStopped = false;

        // First, where are we going?
        Vector3 targetPosition = patrolPositions[patrolIndex];
        agent.SetDestination(targetPosition);

        Vector3 ourPosition = transform.position;
        Vector3 delta = targetPosition - ourPosition;
        delta.y = 0;

        if (delta.magnitude < patrolMinDistance)
        {
            // Go to the next point
            patrolIndex++;

            // If this point is outside of the list (the index is too big),
            // Go back to the first element
            if (patrolIndex >= patrolPositions.Count)
            {
                patrolIndex = 0;
            }
        }
    }
}
