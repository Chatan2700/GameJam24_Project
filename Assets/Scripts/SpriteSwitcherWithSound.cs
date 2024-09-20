using System.Collections;  // Required for IEnumerator
using UnityEngine;

public class SpriteSwitcherWithSound : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite secondSprite;            // The sprite to switch to after 4 seconds
    public Sprite thirdSprite;             // The sprite to switch to when "E" is pressed
    public AudioClip soundClip;            // The sound to play when switching to the third sprite
    public AudioSource audioSource;        // AudioSource to play the sound

    private bool secondSpriteDisplayed = false; // Track if second sprite is already displayed
    private bool thirdSpriteDisplayed = false;  // Track if third sprite has been shown

    void Start()
    {
        // Start the process of switching to the second sprite after a delay
        StartCoroutine(SwitchSpriteAfterDelay(5f)); // 4 seconds delay
    }

    void Update()
    {
        // Check for "E" key press and whether second sprite has been displayed
        if (secondSpriteDisplayed && !thirdSpriteDisplayed && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToThirdSprite();
        }
    }

    // Coroutine that waits for a certain amount of time and then changes to the second sprite
    IEnumerator SwitchSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (spriteRenderer != null && secondSprite != null)
        {
            // Change to the second sprite
            spriteRenderer.sprite = secondSprite;
            secondSpriteDisplayed = true;  // Mark second sprite as displayed
        }
        else
        {
            Debug.LogError("SpriteRenderer or secondSprite is not assigned!");
        }
    }

    // Method to switch to the third sprite and play the sound
    void SwitchToThirdSprite()
    {
        if (spriteRenderer != null && thirdSprite != null)
        {
            // Change to the third sprite
            spriteRenderer.sprite = thirdSprite;
            thirdSpriteDisplayed = true;  // Mark third sprite as displayed

            // Play the sound if AudioSource and AudioClip are assigned
            if (audioSource != null && soundClip != null)
            {
                audioSource.PlayOneShot(soundClip);  // Play sound only when the third sprite is displayed
            }
            else
            {
                Debug.LogError("AudioSource or soundClip is not assigned!");
            }
        }
    }
}
