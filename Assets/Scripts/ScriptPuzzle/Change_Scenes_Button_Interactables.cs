using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scenes_Button_Interactables : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private int PuzzleNeeded;

    public void LoadhouseScene()
    {
        int FinalEventKeyCounter = GameManagement.manager.GetPickupFinalEventKey();
        int DoorKeyCounter = GameManagement.manager.GetPickupDoorkeyCounter();
        if(FinalEventKeyCounter > 4  || DoorKeyCounter >= 1)
        {
            // Carga la escena principal
            Debug.Log("Cargando la Escena " + SceneName);
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            Debug.Log("Coge la llave primero");
        }
    }

    //public void LoadActivePuzzleScene()
    //{
    //    int DoorKeyCounter = GameManagement.manager.GetPickupDoorkeyCounter();

    //    // Carga la escena principal
    //    if (DoorKeyCounter < PuzzleNeeded)
    //    {
    //        GameManagement.manager.resetCounter();
    //        string currentSceneName = SceneManager.GetActiveScene().name;
    //        Debug.Log("Cargando la Escena " + currentSceneName);
    //        SceneManager.LoadScene(currentSceneName);
    //    }
    //    else
    //    {
    //        Debug.Log("No se puede recargar");
    //        return;
    //    }

    }

