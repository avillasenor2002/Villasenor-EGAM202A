using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject obstacletall;
    public GameObject obstacletop;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject spinner;
    public PlayerController scorescript;

    public float randomspwn;
    public float treespwn;
    public GameObject scoreBox;
    public GameObject player;
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    
    private float spwnLow;
    private float spwnHigh;
    public float EarlyLow;
    public float EarlyHigh;
    public float MidLow;
    public float MidHigh;
    public float LateLow;
    public float LateHigh;
    public float EXLow;
    public float EXHigh;
    public bool reset;
    //public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scorescript.score >= 15 && scorescript.score <= 45)
        {
            spwnLow = MidLow; 
            spwnHigh = MidHigh;
        }
        
        if (scorescript.score >= 45 && scorescript.score <= 70)
        {
            spwnLow = LateLow;
            spwnHigh = LateHigh;
        }

        if (scorescript.score >= 70)
        {
            spwnLow = EXLow;
            spwnHigh =EXHigh;
        }
    }

    IEnumerator SpawnObstacles()
    {

        while (true) 
        {

            float waitTime = Random.Range(spwnLow,spwnHigh);

            yield return new WaitForSeconds(waitTime);
            randomspwn = Random.Range(1, 5);
            treespwn = Random.Range(1, 4);

        //Early Game Spawner
            if (randomspwn <= 3 && scorescript.score <= 30) 
            { 
                Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
                Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);
                Instantiate(obstacletop, spawnPoint.position, Quaternion.identity);
                
                //Tree Shenanigains
                if (treespwn <= 2)
                {
                    Instantiate(tree1, new Vector3(Random.Range(-6,-45), 1, Random.Range(175, 178)), Quaternion.identity);
                }
                if (treespwn > 2)
                {
                    Instantiate(tree2, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }

            }

            if (randomspwn > 3 && scorescript.score <= 30)
            {
                Instantiate(obstacletall, spawnPoint.position, Quaternion.identity);
                Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);
                Instantiate(obstacletop, spawnPoint.position, Quaternion.identity);

                //Tree Shenanigains
                if (treespwn <= 2)
                {
                    Instantiate(tree1, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }
                if (treespwn > 2)
                {
                    Instantiate(tree2, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }

            }

        //Late Game Spawner
            if (randomspwn <= 3 && scorescript.score > 30)
            {
                Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
                Instantiate(obstacletop, spawnPoint.position, Quaternion.identity);
                Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);

                //Tree Shenanigains
                if (treespwn <= 2)
                {
                    Instantiate(tree1, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }
                if (treespwn > 2)
                {
                    Instantiate(tree2, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }

            }

            if (randomspwn > 3 && randomspwn <= 5 && scorescript.score >= 30)
            {
                Instantiate(spinner, spawnPoint.position, Quaternion.identity);
                Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);

                //Tree Shenanigains
                if (treespwn <= 2)
                {
                    Instantiate(tree1, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }
                if (treespwn > 2)
                {
                    Instantiate(tree2, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }

            }

            if (randomspwn >= 5 && scorescript.score >= 30)
            {
                Instantiate(obstacletall, spawnPoint.position, Quaternion.identity);
                Instantiate(scoreBox, spawnPoint.position, Quaternion.identity);

                //Tree Shenanigains
                if (treespwn <= 2)
                {
                    Instantiate(tree1, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }
                if (treespwn > 2)
                {
                    Instantiate(tree2, new Vector3(Random.Range(-6, -45), 1, Random.Range(175, 178)), Quaternion.identity);
                }

            }
        }
    }

    //void ScoreUp()
    //{
        //score++;
        //scoreText.text = score.ToString();
    //}

    public void GameStart()
    {
        randomspwn = 0;
        player.SetActive(true);
        StartCoroutine("SpawnObstacles");
        scorescript = GameObject.Find("Player").GetComponent<PlayerController>();
        //InvokeRepeating("ScoreUp", 2f, 1f);
        spwnLow = EarlyLow;
        spwnHigh = EarlyHigh;

    }

    public void GameEnd()
    {
        //player.SetActive(true);
        //StartCoroutine("SpawnObstacles");
        //InvokeRepeating("ScoreUp", 2f, 1f);
        SceneManager.LoadScene("Game");
    }
}
