using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent : MonoBehaviour
{

    public Camera gameCamera;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
                {
                //agent.SetDestination(hitInfo.point);
                }
        }
    }
}
