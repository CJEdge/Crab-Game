using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class CrabMovement : MonoBehaviour {

    // Adjustable parameters
    public float speed = 5f;
    public float jumpHeight = 10f;
    [SerializeField] private float maxSlopeHeight = 45f; // Maximum slope angle in degrees

    // Internal variables
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Vector2 groundNormal;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        rb.linearVelocity = new Vector2(xVelocity, rb.linearVelocity.y);

        // Slope handling
        if (isGrounded && Mathf.Abs(groundNormal.x) > 0.1f) {
            float slopeAngle = Mathf.Atan2(groundNormal.y, groundNormal.x) * Mathf.Rad2Deg;
            if (Mathf.Abs(slopeAngle) > maxSlopeHeight) {
                float slopeDirection = Mathf.Sign(horizontalInput);
                rb.linearVelocity = new Vector2(speed * slopeDirection, rb.linearVelocity.y);
            }
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        // Ground detection and rotation
        if (collision.contacts.Length > 0) {
            ContactPoint2D contact = collision.contacts[0];
            if (contact.normal.y > 0.5f) {
                isGrounded = true;
                groundNormal = contact.normal;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, groundNormal);
            }
        }
    }
}
