using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform spwnHandle;
    public Cannonball cannonballPrefab;

    public float force;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteLaunches());
    }

    // Update is called once per frame
    IEnumerator ExecuteLaunches()
    {
        while (true)
        {
            yield return new WaitForSeconds (frequency);

            Cannonball ball = Instantiate(cannonballPrefab);
            ball.transform.position = spwnHandle.position;
            ball.Launch(spwnHandle.up, force);
        }
    }
}
