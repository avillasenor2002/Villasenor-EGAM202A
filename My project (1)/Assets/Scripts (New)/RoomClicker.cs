using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClicker : MonoBehaviour
{
    public Camera gameCamera;
    public Room[] rooms;
    void Start()
    {
        rooms = FindObjectsOfType<Room>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100)) 
            { 
             Room room = hitInfo.transform.GetComponent<Room>();
                if (room)
                {

                }
                else
                {

                }
            }
        }
    }
}
