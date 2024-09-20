using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Studio_Scene_Controller : MonoBehaviour
{
    private bool isPuzzleOpen;
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject PuzzleInteractable_4;

    // La condicional es la llave(Variable) que desbloquea el evento final en GM
    void Update()
    {


        if (GameManagement.manager.PuzzledCompleted_4 == true)
        {
            Destroy(PuzzleInteractable_4);
            Debug.Log("Destruido el objeto interactuable");
            GameManagement.manager.PuzzledCompleted_4 = false;
        }
    }

    public void OpenPuzzle()
    {
        if (!isPuzzleOpen)
        {
            GameManagement.manager.PuzzledCompleted_4 = true;
            isPuzzleOpen = true; // On access change boolean value
            Debug.Log("Load Studio Puzzle...");
            SceneManager.LoadScene(SceneName);

        }
    }
}
