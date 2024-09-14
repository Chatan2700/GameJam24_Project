using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen_Interactable_Controller : MonoBehaviour
{
    private bool isDialogueOpen;

    public void OpenDialogue()
    {
        if (!isDialogueOpen)
        {
            isDialogueOpen = true; // On access change boolean value
            Debug.Log("Open Dialogue...");

        }
    }
}
