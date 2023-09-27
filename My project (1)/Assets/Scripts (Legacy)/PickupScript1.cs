using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript1 : MonoBehaviour
{
    public bool ishoney;
    public SpriteRenderer ObjIMG;
    public Sprite StopIMG;
    public Sprite GoIMG;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (ishoney == true)
        {
            gameObject.layer = 9;
            gameObject.GetComponent<SpriteRenderer>().sprite = GoIMG;
        }

        if (ishoney == false)
        {
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().sprite = StopIMG;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetMouseButtonDown(1))
        {
            ishoney = false;
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
