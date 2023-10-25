using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Fish;

public class RapidEnd : MonoBehaviour
{
    public ClickState currentState;
    public enum ClickState
    {
        Idle,
        Action
    }

    public GameObject failTextEarly;
    public GameObject failTextLate;
    public GameObject VictoryState;
    public Cast cast;
    public GameObject fish;
    public GameObject caughtfish;
    public GameObject fishingrod;
    private float waitTime = 3.0f;
    private float timer = 0.0f;
    public bool starting;
    public bool Done;

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

        if (Input.GetKeyDown(KeyCode.Space) && timer <= waitTime)
        {
            VictoryState.SetActive(true);
            fish.SetActive(false);
            caughtfish.SetActive(true);
            fishingrod.SetActive(false);
            Victory.Priority = 100;
            MainGame.Priority = 0;
            Done = true;
        }
        else if (timer > waitTime && Done == false)
        {
            failTextLate.SetActive(true);
            fish.SetActive(false);
        }
    }
}
