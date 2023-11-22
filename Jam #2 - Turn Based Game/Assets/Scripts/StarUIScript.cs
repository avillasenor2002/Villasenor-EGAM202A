using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUIScript : MonoBehaviour
{
    public LineForce player;
    public float shownum;
    public SpriteRenderer star;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.starcollect >= shownum)
        {
            star.color = new Color(255, 255, 255, 255);
        }    
    }
}
