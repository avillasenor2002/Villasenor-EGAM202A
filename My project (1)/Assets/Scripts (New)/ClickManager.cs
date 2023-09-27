using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera camera1;

    void FixedUpdate()
    {
        Vector2 mousePosition = Input.mousePosition;

        Ray mouseOriginAndDirection = camera1.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(mouseOriginAndDirection, 100))
        {
            ///ClickableObject clickableObject = hitInfo.transform.GetComponent<ClickableObject>();
            //if (clickableObject) 
            //{
               //clickableObject.Clicked();
            //}
        }

        Debug.DrawRay (mouseOriginAndDirection.origin, mouseOriginAndDirection.direction * 100);
    }
}
