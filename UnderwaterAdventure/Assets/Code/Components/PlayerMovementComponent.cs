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
        private float moveSpeed;

        [SerializeField]
        private float jumpPower;

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

        public bool IsGrounded
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
            if (this.IsGrounded)
            {
                if (context.performed)
                {
                    rb.AddForce(new Vector2(0, jumpPower));
                }
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
    }
}
