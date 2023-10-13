using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject scoreBox;
    public GameObject player;
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    
    public float spwnLow;
    public float spwnHigh;
    public bool reset;
    //public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (reset == true)
        //{
           // SceneManager.LoadScene("Game");
        //}
    }

    IEnumerator SpawnObstacles()
    {

        while (true) 
        {

            float waitTime = Random.Range(spwnLow,spwnHigh);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
            Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);

        }
    }

    //void ScoreUp()
    //{
        //score++;
        //scoreText.text = score.ToString();
    //}

    public void GameStart()
    {
        player.SetActive(true);
        StartCoroutine("SpawnObstacles");
        //InvokeRepeating("ScoreUp", 2f, 1f);

    }

    public void GameEnd()
    {
        //player.SetActive(true);
        //StartCoroutine("SpawnObstacles");
        //InvokeRepeating("ScoreUp", 2f, 1f);
        SceneManager.LoadScene("Game");

    }
}
