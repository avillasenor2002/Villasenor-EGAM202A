using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    bool canJump;
    bool endgame;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject gameOverScreen;
    public GameObject gameOverBG;
    public GameObject scoredisplay;
    public GameObject runPart;
    public GameObject landPart;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        endgame= false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true) 
        {
            //its jumpin time
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

        if (endgame == true)
        {
            gameOverScreen.SetActive(true);
            gameOverBG.SetActive(true);
            scoredisplay.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            //runPart.SetActive(true);
            landPart.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            //runPart.SetActive(false);
            landPart.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            //SceneManager.LoadScene("Game");
            endgame = true;
        }
        if (other.gameObject.tag == "Score+")
        {
            score++;
            scoreText.text = score.ToString();
            finalScoreText.text = score.ToString();
        }
    }
}
