using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightstandController : MonoBehaviour
{
    private bool isPuzzleOpen;
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject NotificationDesactivate;
    [SerializeField] private GameObject PuzzleInteractable_1;

    void Update()
    {
        if (GameManagement.manager.PuzzledCompleted_1 == true)
        {
            Destroy(PuzzleInteractable_1);
            Debug.Log("Destruido el objeto interactuable");
            GameManagement.manager.PuzzledCompleted_1 = false;
        }
    }

    public void OpenPuzzle()
    {
        if (!isPuzzleOpen)
        {
            isPuzzleOpen = true; // On access change boolean value
            Debug.Log("Load Nightstand Puzzle...");
            SceneManager.LoadScene(SceneName);

        }
    }
}
