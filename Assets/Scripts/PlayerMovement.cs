using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float sprintSpeed = 4f;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 movement; // Input
    //private Animator animator;
    private float originalScale = 0.75f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for movement
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        AnimateMovement();
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody
        rb.velocity = new Vector2 (movement.x * moveSpeed, rb.velocity.y);
    }

    void AnimateMovement()
    {
        // Flip the character Sprite
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-originalScale, originalScale, originalScale);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(originalScale, originalScale, originalScale);
        }

        // Control animation states

        //if (movement.x != 0)
        //{
        //    animator.SetBool("isWalking", true);
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //}

    }

}
