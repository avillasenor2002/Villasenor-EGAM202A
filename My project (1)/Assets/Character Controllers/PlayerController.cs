using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;

    void FixedUpdate()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameObject.tag == "PlayerB") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }

        //PlayerA's Left Right Movement
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        //PlayerB's Left Right Movement
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.LeftArrow)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.RightArrow)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }
}
