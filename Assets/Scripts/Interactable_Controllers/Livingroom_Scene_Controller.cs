using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Livingroom_Scene_Controller : MonoBehaviour
{
    private bool isPuzzleOpen;
    [SerializeField] private string SceneName;

    public void OpenPuzzle()
    {
        if (!isPuzzleOpen)
        {
            isPuzzleOpen = true; // On access change boolean value
            Debug.Log("Load Livingroom Puzzle...");
            SceneManager.LoadScene(SceneName);

        }
    }
}
