using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange; //Checks if the player is in Range
    public KeyCode interactKey; // The input in order to interact with the gameobject
    public UnityEvent interactAction; // The action that is to supposed to happened after input.
    public string parentName; // The name of the Gameobject parent

    [SerializeField] private string NotifyObject;
    [SerializeField] private string DeNotifyObject;

    // Start is called before the first frame update
    void Start()
    {
        // Print the name of the parent GameObject at the start
        if (transform.parent != null)
        {
            parentName = transform.parent.gameObject.name;
            Debug.Log(parentName);

        }
        else
        {
            Debug.Log("This GameObject has no parent.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) //Player is in range
        {
            if (Input.GetKeyDown(interactKey)) // and is pressing the key E or F
            {
                interactAction.Invoke(); //Fire the event 
            }
        }

    }

    //void Update()
    //{
    //    if (isInRange && Input.GetKeyDown(interactKey)) // Player is in range and key is pressed
    //    {
    //        interactAction.Invoke(); // Invoke the event/action
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in Range with " + parentName);

            // Dependiendo del parentName, llamamos a diferentes métodos en PlayerNotifications
            switch (parentName)
            {
                case "NightStand_Puzzle":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerNightstand();
                    break;
                case "Bathroom_Puzzle":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerBathroom();
                    break;
                case "Office_Puzzle":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyStudioInside();
                    break;
                case "LivingroomPuzzle":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyLivingroomInsidePuzzle();
                    break;
                case "Kitchen_Puzzle":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyKitchenInsideDialogue();
                    break;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        Debug.Log("Player now not in Range with " + parentName);

        // Dependiendo del parentName, llamamos a diferentes métodos en PlayerNotifications
        switch (parentName)
        {
            case "NightStand_Puzzle":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerNightstand();
                break;
            case "Bathroom_Puzzle":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerBathroom();
                break;
            case "Office_Puzzle":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyStudioOutside();
                break;
            case "LivingroomPuzzle":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyLivingroomOutsidePuzzle();
                break;
            case "Kitchen_Puzzle":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyKitchenOutsideDialogue();
                break;
        }
  
    }

}
