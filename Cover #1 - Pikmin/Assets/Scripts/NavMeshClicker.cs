using Cinemachine;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditorInternal.VersionControl.ListControl;

public class NewNavMeshClicker : MonoBehaviour
{
    public Camera gameCamera;
    public NavMeshAgent agent;
    public NavMeshAgent selector;
    public GameObject indicator;
    // We'll fill these lists in Start() via code
    public Room1[] rooms1;
    public Room2[] room2;
    public NavMeshAgent[] allCameras;
    public NavMeshAgent Null;
    public NavMeshAgent[] tresures;
    public GameObject treasure;
    public GameObject home;

    public enum States
    {
        Idle,
        Carry,
        Follow,
    }

    public States currentState;

    void Start()
    {
        // This will find EVERY Room.cs script in the scene
        rooms1 = FindObjectsOfType<Room1>();
        room2 = FindObjectsOfType<Room2>();
        // This will find EVERY CinemachineVirtualCamera in the scene
        allCameras = FindObjectsOfType<NavMeshAgent>();
    }

    void Update()
    {
        // Turn the mouse into world position
        if (Input.GetMouseButtonDown(0))
        {
            // Turn the mouse into world positions
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            // Did we hit ANYTHING?
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 999))
            {
                Room1 room = hitInfo.transform.GetComponent<Room1>();
                Room2 room2 = hitInfo.transform.GetComponent<Room2>();
                RoomButton roomButton = hitInfo.transform.GetComponent<RoomButton>();

                if (room != null && hitInfo.collider.gameObject.tag != "Treasure")
                {
                    // Switch to this room's camera
                    agent = (room.newagent);
                    currentState = States.Follow;
                }

                if (hitInfo.collider.gameObject.tag == "Treasure")
                {
                    // Switch to this room's camera
                    //currentState = States.Carry;
                    //Debug.Log("yeah this works");
                    treasure = hitInfo.collider.gameObject;
                    //agent.SetDestination(hitInfo.point);
                    currentState = States.Carry;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            agent = Null;
            currentState = States.Idle;
        }

        indicator.transform.position = agent.transform.position;

        // Respond to clicks
        if (Input.GetMouseButtonDown(0) && currentState == States.Follow)
        {
            // Mouse to world position
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            // Hit anything?
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                // Make the agent go to the collision point
                agent.SetDestination(hitInfo.point);
                selector.SetDestination(hitInfo.point);
            }
        }

        if (currentState== States.Carry && agent.transform.position != treasure.transform.position) 
        {
            //treasure.transform.position = agent.transform.position;
            agent.SetDestination(treasure.transform.position);
        }

        if (currentState == States.Carry && agent.transform.position == treasure.transform.position)
        {
            Debug.Log("yeah this works");
            treasure.transform.position = agent.transform.position;
            agent.SetDestination(home.transform.position);
        }
    }
}

