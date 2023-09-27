using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        SceneManager.LoadScene("Demo Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
