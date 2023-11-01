using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Fish;

public class RapidEnd : MonoBehaviour
{
    public ClickState currentState;
    public enum ClickState
    {
        Idle,
        Action,
        Finish
    }

    public GameObject failTextEarly;
    public GameObject failTextLate;
    public GameObject VictoryAnchovy;
    public GameObject VictorySeaBass;
    public GameObject VictorySturgeon;
    public Cast cast;
    public Spawnscipt Spawner;
    public GameObject fish;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject caughtfishAnchovy;
    public GameObject caughtfishSeaBass;
    public GameObject caughtfishSturgeon;
    public GameObject fishingrod;
    public GameObject SplashPart;
    public float waitTime;
    private float splashTime = 4.0f;
    private float timer = 0.0f;
    public bool starting;
    public bool Done;
    public bool Caught;

    public CinemachineVirtualCamera MainGame;
    public CinemachineVirtualCamera Victory;

    // Start is called before the first frame update
    void Start()
    {
        starting = true;
        // This will find EVERY CinemachineVirtualCamera in the scene
        MainGame.Priority = 100;
        Victory.Priority = 0;
    }

    void Update()
    {
        switch (currentState)
        {
            case ClickState.Idle:
                UpdateIdle();
                break;
            case ClickState.Action:
                UpdateAction();
                break;
            case ClickState.Finish:
                UpdateAction();
                break;
        }
    }

    void UpdateIdle()
    {
        if (Input.GetKeyDown(KeyCode.Space) && starting == false)
        {
            failTextEarly.SetActive(true);
            fish.SetActive(false);
            Done = true;
        }
    }

    void UpdateAction()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer <= waitTime && Done == false)
        {
            Done = true;
            Caught = true;
            currentState = ClickState.Finish;
        }
        else if (timer > waitTime && Done == false)
        {
            failTextLate.SetActive(true);
            fish.SetActive(false);
            fish2.SetActive(false);
            fish3.SetActive(false);
        }

        if (Done == true && Caught == true)
        {
            timer += Time.deltaTime;

            if (timer <= splashTime)
            {
                SplashPart.SetActive(true);
                cast.lureDown = true;
            }
            else if (timer > splashTime)
            {
                fish.SetActive(false);
                fish2.SetActive(false);
                fish3.SetActive(false);
                
                fishingrod.SetActive(false);
                cast.gameObject.SetActive(false);
                Victory.Priority = 100;
                MainGame.Priority = 0;
                
                if (Spawner.fishSpwn <= 3)
                {
                    VictoryAnchovy.SetActive(true);
                    caughtfishAnchovy.SetActive(true);
                }
                else if (Spawner.fishSpwn > 3 && Spawner.fishSpwn <= 6)
                {
                    VictorySeaBass.SetActive(true);
                    caughtfishSeaBass.SetActive(true);
                }
                else if (Spawner.fishSpwn > 6)
                {
                    VictorySturgeon.SetActive(true);
                    caughtfishSturgeon.SetActive(true);
                }
            }
        }
    }

    void UpdateFinish()
    {
        timer += Time.deltaTime;

        if (timer <= splashTime)
        {
            SplashPart .SetActive(true);
            cast.lureDown = true;
        }
        else if (timer > splashTime)
        {
            //VictoryState.SetActive(true);
            fish.SetActive(false);
            fish2.SetActive(false);
            fish3.SetActive(false);
            //caughtfish.SetActive(true);
            fishingrod.SetActive(false);
            Victory.Priority = 100;
            MainGame.Priority = 0;
        }
    }
}
