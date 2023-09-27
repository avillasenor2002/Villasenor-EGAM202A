using UnityEngine;
using System.Collections;

public class ControllerFrogNew : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    public float flutterjump;
    float moveVelocity;
    public bool groundcol;
    public bool flipped;

    public Sprite Idle;
    public Sprite Forward;
    public Sprite Backwards;
    public Sprite Jumping;
    public GameObject player;
    public Camera mainCamera;

    public enum ObjectState
    {
        Ground,
        Jump,
        Jump2,
        Finished
    }

    public ObjectState currentState;

    void Update()
    {
        switch (currentState)
        {
            case ObjectState.Ground:
                UpdateGround();
                break;

            case ObjectState.Jump:
                UpdateJump();
                break;

            case ObjectState.Jump2:
                UpdateJump2();
                break;

            case ObjectState.Finished:
                UpdateFinished();
                break;
        }

        moveVelocity = 0;

            var mouseScreenPos = Input.mousePosition;
            var startingScreenPos = mainCamera.WorldToScreenPoint(this.transform.position);
            mouseScreenPos.x -= startingScreenPos.x;

        if (mouseScreenPos.x < this.transform.position.x) //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            flipped= true;
        }

        if (mouseScreenPos.x > this.transform.position.x) //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            flipped= false;
        }
    }

    void UpdateJump2()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flutterjump);
        }

        //PlayerA's Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }
        groundcol = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void UpdateJump()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, flutterjump);
            currentState = ObjectState.Jump2;
        }

        //PlayerA's Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        player.GetComponent<SpriteRenderer>().sprite = Jumping;
        groundcol = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void UpdateGround()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump;
        }

        //PlayerA's Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
            //player.GetComponent<SpriteRenderer>().sprite = Backwards;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && flipped == false || Input.GetKey(KeyCode.A) && flipped == false)
        {
            player.GetComponent<SpriteRenderer>().sprite = Backwards;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && flipped == true || Input.GetKey(KeyCode.A) && flipped == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = Forward;
        }

        //Right Movement
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            //player.GetComponent<SpriteRenderer>().sprite = Forward;
        }

        if (Input.GetKey(KeyCode.RightArrow) && flipped == true || Input.GetKey(KeyCode.D) && flipped == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = Backwards;
        }

        if (Input.GetKey(KeyCode.RightArrow) && flipped == false || Input.GetKey(KeyCode.D) && flipped == false)
        {
            player.GetComponent<SpriteRenderer>().sprite = Forward;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            player.GetComponent<SpriteRenderer>().sprite = Idle;
        }


        groundcol = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetMouseButtonDown(1))
        {
            currentState = ObjectState.Finished;
        }
    }

    void UpdateFinished()
    {
        if (Input.GetMouseButtonUp(1))
        {
            currentState = ObjectState.Ground;
        }
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Ground")
        {
            currentState = ObjectState.Ground;
            player.GetComponent<SpriteRenderer>().sprite = Idle;
        }
        if (collison.gameObject.tag == "Good")
        {
            currentState = ObjectState.Finished;
        }
        if (collison.gameObject.tag == "BulletA")
        {
            Debug.Log ("Player hit");
        }
    }
}
