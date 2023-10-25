using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumScriptProto : MonoBehaviour
{
    public enum PikminColor
    {
        Red,
        Blue, 
        Yellow,
        Purple
                
    }

    public PikminColor color;
    public Renderer mainRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (color == PikminColor.Blue)
        {
            mainRenderer.material.color = Color.blue;
        }
        else if (color== PikminColor.Red)
        {
            mainRenderer.material.color = Color.red;
        }

        //switch (color)
        //{
            //case PikminColor.Red:
            //case PikminColor.Yellow:
                mainRenderer.material.color = Color.green;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
