using UnityEngine;

public class playerMovement : MonoBehaviour




{

public float moveSpeed = 3f;
public float jumpForce = 8f;
public bool isGrounded;
private Rigidbody2D playerBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerBody.freezeRotation = true; // Prevent rotation
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        playerBody.linearVelocity = new Vector2(moveInput * moveSpeed, playerBody.linearVelocity.y);


        // When the player presses space and they are grounded, upward force it added to the player and isGrounded bool is changed to false.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {


            // playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpForce);
            playerBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;


        }

    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        //When player collides with ground, isGrounded is true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}

