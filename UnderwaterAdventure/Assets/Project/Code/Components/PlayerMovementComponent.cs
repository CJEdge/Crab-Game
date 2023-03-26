using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Components
{
    public class PlayerMovementComponent : MonoBehaviour
    {

        #region Serialized Fields

        [SerializeField]
        private Rigidbody2D rb;

        [SerializeField]
        private GroundColliderComponent groundColliderComponent;

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float jumpPower;

		[SerializeField]
		private float maxJumpHoldTime;

		[SerializeField]
		private float jumpHoldMultiplier;

        #endregion


        #region Properties

        public bool GameStarted
        {
            get;
            set;
        } = true;

        public float Horizontal
        {
            get;
            set;
        }

        public bool IsSideAttacking
        {
            get;
            set;
        }

        public bool IsUpAttacking
        {
            get;
            set;
        }

        public bool IsSDownAttacking
        {
            get;
            set;
        }

        public bool IsAttackHeld
        {
            get;
            set;
        }

		[field : SerializeField]
		public bool JumpHeld {
			get;
			set;
		} = false;

		[field : SerializeField]
		public float JumpHoldTime {
			get;
			set;
		} = 0;

        #endregion


        #region Monobehaviours

        public void FixedUpdate()
        {
            if (!this.GameStarted)
            {
                return;
            }
            if (this.IsSDownAttacking)
            {
                return;
            }
            rb.AddForce(new Vector2(this.Horizontal * moveSpeed, 0));
        }

        #endregion


        #region Public Methods

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!this.GameStarted)
            {
                return;
            }
            this.Horizontal = context.ReadValue<float>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!this.GameStarted)
            {
                return;
            }
            if (groundColliderComponent.IsGrounded)
            {
                if (context.performed)
                {
					this.JumpHeld = true;
				}
            }
			if (context.canceled) {
				this.JumpHeld = false;
			}
        }

        public void OnSideAttack(InputAction.CallbackContext context)
        {
            if (!this.GameStarted)
            {
                return;
            }
            this.IsSideAttacking = context.performed;
        }

        public void OnUpAttack(InputAction.CallbackContext context)
        {
            if (!this.GameStarted)
            {
                return;
            }
            this.IsUpAttacking = context.performed;
        }

        public void OnDownAttack(InputAction.CallbackContext context)
        {
            if (!this.GameStarted)
            {
                return;
            }
            this.IsSDownAttacking = context.performed;
        }

		#endregion


		#region MonoBehaviours

		public void Update() {
			if (this.JumpHeld) {
				this.JumpHoldTime += Time.deltaTime + jumpHoldMultiplier;
				if (JumpHoldTime >= maxJumpHoldTime) {
					this.JumpHeld = false;
				}
				else {
					PerformJump();
				}
			}
			else {
				this.JumpHoldTime = 0;
			}
		}
		#endregion

		#region Private Methods

		private void PerformJump() {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.velocity = new Vector2(0, jumpPower);
			}

		#endregion
	}
}
