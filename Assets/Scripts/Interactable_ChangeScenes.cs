using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_ChangeScenes : MonoBehaviour
{
    public bool isInRange; //Checks if the player is in Range
    public KeyCode interactKey; // The input in order to interact with the gameobject
    public UnityEvent interactAction; // The action that is to supposed to happened after input.
    private string parentName; // The name of the Gameobject parent

    public Transform cameraTarget;  // The camera's target to move to (next room's center or position)
    public float transitionSpeed = 5f;  // Speed of the smooth transition
    [SerializeField] private Transform player;
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    private bool isTransitioning = false;  // Flag to check if transition is happening
    private Vector3 targetPosition;  // Where the camera should move to

    [SerializeField] private GameObject triggerDesactivar;

    // Start is called before the first frame update
    void Start()
    {
        // Print the name of the parent GameObject at the start
        if (transform.parent != null)
        {
            parentName = transform.parent.gameObject.name;
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
    public void StartCameraTransition()
    {
        if (!isTransitioning)
        {
            // Start the camera transition
            targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, Camera.main.transform.position.z);
            StartCoroutine(SmoothCameraTransition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in Range with " + parentName);

            // Dependiendo del parentName, llamamos a diferentes métodos en PlayerNotifications
            switch (parentName)
            {
                case "FatherInsideKitchen":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerInsideKitchen();
                    break;
                case "FatherOutsideKitchen":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerOutsideKitchen();
                    break;
                case "FatherStudioInside":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerInsideStudio();
                    break;
                case "FatherStudioOutside":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyPlayerOutsideStudio();
                    break;
                case "FatherInsideLivingroom":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyLivinroomInside();
                    break;
                case "FatherOutsideLivingroom":
                    collision.gameObject.GetComponent<PlayerNotifications>().NotifyLivinroomOutside();
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
            case "FatherInsideKitchen":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerInsideKitchen();
                break;
            case "FatherOutsideKitchen":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerOutsideKitchen();
                break;
            case "FatherStudioInside":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerInsideStudio();
                break;
            case "FatherStudioOutside":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyPlayerOutsideStudio();
                break;
            case "FatherInsideLivingroom":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyLivinroomInside();
                break;
            case "FatherOutsideLivingroom":
                collision.gameObject.GetComponent<PlayerNotifications>().DeNotifyLivinroomOutside();
                break;
        }
    }

    private System.Collections.IEnumerator SmoothCameraTransition()
    {
        triggerDesactivar.SetActive(false);
        isTransitioning = true;

        // While the camera hasn't reached the target position
        while (Vector3.Distance(Camera.main.transform.position, targetPosition) > 0.05f)
        {
            // Smoothly move the camera towards the target position
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * transitionSpeed);
            player.position = targetPosition - new Vector3(xAxis, yAxis, -1);
            yield return null;  // Wait for the next frame
        }

        // Snap to the exact target position at the end
        Camera.main.transform.position = targetPosition;
        isTransitioning = false;
        triggerDesactivar.SetActive(true);
    }
}
