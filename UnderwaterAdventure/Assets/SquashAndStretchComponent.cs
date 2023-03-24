using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashAndStretchComponent : MonoBehaviour
{
    // The object to squash
    public Transform objectToSquash;

    // The maximum amount to squash the object
    public float maxSquashAmount = 0.5f;

    // The speed at which the object squashes
    public float squashSpeed = 10f;

    // The rigidbody component of the object
    [SerializeField]
    private Rigidbody2D rb;

    // The original scale of the object
    private Vector3 originalScale;

    void Start() {

        // Get the original scale of the object
        originalScale = objectToSquash.localScale;
    }

    void Update() {
        // Get the absolute value of the object's velocity
        Vector2 velocity = rb.velocity;
        float xVelocity = Mathf.Abs(velocity.x);
        float yVelocity = Mathf.Abs(velocity.y);

        // Calculate the squash amount based on the velocity and the maximum squash amount
        float squashAmountX = Mathf.Clamp(xVelocity / squashSpeed, 0f, maxSquashAmount);
        float squashAmountY = Mathf.Clamp(yVelocity / squashSpeed, 0f, maxSquashAmount);

        // Calculate the stretch amount in the other direction
        float stretchAmountY = (squashAmountX * maxSquashAmount) * 10f;
        float stretchAmountX = (squashAmountY * maxSquashAmount) * 10f;

        // Set the scale of the object based on the original scale and the squash and stretch amounts
        objectToSquash.localScale = new Vector3(originalScale.x - squashAmountX + stretchAmountX, originalScale.y - squashAmountY + stretchAmountY, originalScale.z);
    }
}
