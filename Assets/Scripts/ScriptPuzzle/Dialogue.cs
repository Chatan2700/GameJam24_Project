using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textspeed;

    private int index;
    private bool dialogueEnded;

    void Start()
    {
        textComponent.text = string.Empty;
        dialogueEnded = false;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (!dialogueEnded)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
            else
            {
                // If dialogue ended, restart it
                RestartDialogue();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        dialogueEnded = false;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        //Type characters 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            dialogueEnded = true;
            gameObject.SetActive(false);
            // Set flag to indicate the dialogue has ended
        }
    }

    void RestartDialogue()
    {
        // Reset the dialogue when it ends and the player clicks or presses a key
        textComponent.text = string.Empty;
        StartDialogue();
    }
}
