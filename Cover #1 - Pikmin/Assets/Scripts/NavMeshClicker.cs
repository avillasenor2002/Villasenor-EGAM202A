using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshClicker : MonoBehaviour
{
    public Camera gameCamera;
    public NavMeshAgent agent;
    public NavMeshAgent selector;
    public GameObject indicator;
    // We'll fill these lists in Start() via code
    public Room1[] rooms1;
    public NavMeshAgent[] allCameras;
    public NavMeshAgent Null;

    void Start()
    {
        // This will find EVERY Room.cs script in the scene
        rooms1 = FindObjectsOfType<Room1>();

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
                RoomButton roomButton = hitInfo.transform.GetComponent<RoomButton>();

                if (room != null)
                {
                    // Switch to this room's camera
                    agent = (room.newagent);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            agent = Null;
        }

        indicator.transform.position = agent.transform.position;

        // Respond to clicks
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
                selector.SetDestination(hitInfo.point);
            }
        }
    }
}
