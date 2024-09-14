using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform cameraTarget;  // The camera's target to move to (next room's center or position)
    public float transitionSpeed = 5f;  // Speed of the smooth transition
    [SerializeField] private Transform player;
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;



    private bool isTransitioning = false;  // Flag to check if transition is happening
    private Vector3 targetPosition;  // Where the camera should move to

    [SerializeField] private GameObject triggerDesactivar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            // Start the camera transition
            targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, Camera.main.transform.position.z);
            StartCoroutine(SmoothCameraTransition());
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
            player.position = targetPosition - new Vector3(xAxis,yAxis,-1);
            yield return null;  // Wait for the next frame
        }

        // Snap to the exact target position at the end
        Camera.main.transform.position = targetPosition;
        isTransitioning = false;
        triggerDesactivar.SetActive(true);
    }
}
