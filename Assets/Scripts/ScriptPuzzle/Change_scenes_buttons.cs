using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scenes_buttons : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private int PuzzleNeeded;

    public void LoadhouseScene()
    {
        // Carga la escena principal
        Debug.Log("Cargando la Escena " + SceneName);
        SceneManager.LoadScene(SceneName);
    }

    public void LoadActivePuzzleScene()
    {
        int puzzle = GameManagement.manager.GetPuzzleCounter();

        // Carga la escena principal
        if (puzzle < PuzzleNeeded)
        {
            GameManagement.manager.resetCounter();
            string currentSceneName = SceneManager.GetActiveScene().name;
            Debug.Log("Cargando la Escena " + currentSceneName);
            SceneManager.LoadScene(currentSceneName);
        }
        else
        {
            Debug.Log("No se puede recargar");
            return;
        }
        
    }
}
