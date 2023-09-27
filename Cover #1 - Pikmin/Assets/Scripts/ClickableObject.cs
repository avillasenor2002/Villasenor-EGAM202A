using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public bool isclicked;

    public void Clicked()
    {
        isclicked = true;
    }

    public void Update()
    {

    }
}
