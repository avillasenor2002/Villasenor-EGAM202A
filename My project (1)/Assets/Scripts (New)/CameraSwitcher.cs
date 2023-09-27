using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<CinemachineVirtualCamera> cameraList;
    public int activeCameraIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            activeCameraIndex++;

            if (activeCameraIndex >= cameraList.Count)
            {
                activeCameraIndex = 0;
            }

            for (int i = 0; i < cameraList.Count; i++)
            {
                int newPriority = 0;
                if (i == activeCameraIndex)
                {
                    newPriority = 100;
                }
                cameraList[i].Priority = newPriority;
            }
        }
    }
}
