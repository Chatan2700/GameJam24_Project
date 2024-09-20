using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudioDoorController : MonoBehaviour
{
    private bool isOpen;
    [SerializeField] private GameObject InsideStudio;

    public void OpenStudioDoor()
    {
        if(!isOpen)
        {
            int DoorkeyCounter = GameManagement.manager.GetPickupDoorkeyCounter();

            if (DoorkeyCounter > 0)
            {

                isOpen = true; // On access change boolean value
                InsideStudio.SetActive(true);
                Debug.Log("Set active the Inside door child...");
                GameManagement.manager.UseDoorkey();
                GameManagement.manager.UseFinalEventKey();
            }
            else
            {
                Debug.Log("Consigue la llave primero");
            }

        }
    }
}
