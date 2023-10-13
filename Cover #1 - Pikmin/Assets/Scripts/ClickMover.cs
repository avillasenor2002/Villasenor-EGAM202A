using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMover : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject selector;
    public bool firstClick;

    // Quick variable for remembering the last selected character
    private ClickCharacter lastCharacter;


    private void Start()
    {
        firstClick= false;
    }
    void Update()
    {

        // Turn mouse to world
        Vector2 screenPosition = Input.mousePosition;
        Ray screenRay = gameCamera.ScreenPointToRay(screenPosition);

        // On left click
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(screenRay, out RaycastHit hitInfo))
            {
                ClickCharacter character = hitInfo.transform.GetComponent<ClickCharacter>();
                ClickTreasure treasure = hitInfo.transform.GetComponent<ClickTreasure>();

                // Hit a character?
                if (character != null)
                {
                    lastCharacter = character;
                    firstClick= true;
                }
                // Hit a treasure?
                else if (treasure != null)
                {
                    if (lastCharacter != null)
                    {
                        lastCharacter.MoveTo(treasure);
                    }
                }
                // Hit something else?
                else
                {
                    if (lastCharacter != null)
                    {
                        lastCharacter.MoveTo(hitInfo.point);
                    }
                }
            }
        }

        // Right click
        else if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(screenRay, out RaycastHit hitInfo))
            {
                ClickCharacter character = hitInfo.transform.GetComponent<ClickCharacter>();
                
                if (character != null)
                {
                    character.ForgetTreasure();
                }
            }
        }

        if (firstClick == true)
        {
            selector.transform.position = lastCharacter.transform.position;
        }
    }
}
