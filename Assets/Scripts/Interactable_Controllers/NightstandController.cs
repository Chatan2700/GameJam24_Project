using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightstandController : MonoBehaviour
{
    private bool isPuzzleOpen;
    
    public void OpenPuzzle()
    {
        if (!isPuzzleOpen)
        {
            isPuzzleOpen = true; // On access change boolean value
            Debug.Log("Load Nightstand Puzzle...");

        }
    }
}
