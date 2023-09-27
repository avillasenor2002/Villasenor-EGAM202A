using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public bool ishoney;
    public SpriteRenderer ObjIMG;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (ishoney == true)
        {
            gameObject.layer = 9;
            ObjIMG.color = new Color32(255, 220, 107, 255);
        }

        if (ishoney == false)
        {
            gameObject.layer = 10;
            ObjIMG.color = new Color32(159, 159, 159, 255);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetMouseButtonDown(1))
        {
            ishoney= false;
        }
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "BulletA")
        {
            ishoney= true;
        }
    }
}
