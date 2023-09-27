using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Renderer objrenderer;

    public void Clicked()
    {
        objrenderer.material.color = Color.red;
    }
}
