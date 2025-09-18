using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components {
    public class GroundColliderComponent : MonoBehaviour
    {
		#region Serialized Fields

		[SerializeField]
		private Rigidbody2D rb;

		[SerializeField]
		private PlayerMovementComponent playerMovementComponent;

		[SerializeField]
		private float coyoteTime = 0.05f;

		[SerializeField]
		private float jumpQueueDistance = 0.2f;

		#endregion


		#region Properties

		public int CurrentCollisions {
            get;
            set;
        }

		public bool CollidingWithGround {
			get {
				return this.CurrentCollisions >= 1;
			}
		}

        public bool IsGrounded {
			get {
				return CoyoteTimeCounter < coyoteTime;
				}
        }

		public float CoyoteTimeCounter {
			get;
			set;
		} = 0;

		[field : SerializeField]
		public bool JumpQueued {
			get;
			set;
		}

        #endregion


        #region Collision Checks

        private void OnTriggerEnter2D(Collider2D collision)
        {
            this.CurrentCollisions++;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            this.CurrentCollisions--;
        }

		#endregion


		#region MonoBehaviours

		private void Update() {
			if (this.CollidingWithGround) {
				this.CoyoteTimeCounter = 0f;
			}
			else {
				this.CoyoteTimeCounter += Time.deltaTime;
			}
		}

		#endregion
	}
}
