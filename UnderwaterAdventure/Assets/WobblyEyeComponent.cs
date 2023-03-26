using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components { 
public class WobblyEyeComponent : MonoBehaviour
{
        [SerializeField]
        private Rigidbody2D rb; 

        [SerializeField]
        private bool inverted;

		[SerializeField]
		private float maxDistance;

        public Transform target; // the transform of the character's head
        public float stiffness = 200f; // how stiff the spring is
        public float damping = 20f; // how much the spring oscillations are damped
        public float mass = 0.1f; // the mass of the eyes
        public float speed = 10f; // how quickly the eyes should move

        private Vector3 startingLocalPosition; // the starting position of the eyes
        private Vector3 velocity; // the velocity of the eyes
        private Vector3 force; // the force acting on the eyes

        void Start() {
            startingLocalPosition = transform.localPosition;
            rb = target.GetComponent<Rigidbody2D>();
        }

        void Update() {
            int invert = inverted ? 1 : -1;
            Vector2 targetVelocity = -rb.velocity;
            Vector3 targetPosition = startingLocalPosition + new Vector3(targetVelocity.x, targetVelocity.y, 0f) / 10f;
            Vector3 displacement = transform.localPosition + (invert * targetPosition);
            force = -stiffness * displacement - damping * velocity;
            velocity += force / mass * Time.deltaTime;
            transform.localPosition += velocity * Time.deltaTime;
			float clampedX = Mathf.Clamp(transform.localPosition.x, startingLocalPosition.x - maxDistance, startingLocalPosition.x + maxDistance);
			float clampedY = Mathf.Clamp(transform.localPosition.y, startingLocalPosition.y - maxDistance, startingLocalPosition.y + maxDistance);
			Vector3 clampedTransform = new Vector3( clampedX,clampedY,0);
			transform.localPosition = clampedTransform;
			transform.rotation = target.rotation;
        }
    }
}
