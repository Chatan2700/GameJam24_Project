using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom_Scene_Controller : MonoBehaviour
{
    private bool isSceneOpen; //boolean to check if the scene was opened

    public void OpenScene()
    {
        if (!isSceneOpen)
        {
            isSceneOpen = true; // On access change boolean value
            Debug.Log("Load Bathroom Scene...");

        }
    }
}
