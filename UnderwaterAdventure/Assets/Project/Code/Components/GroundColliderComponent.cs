using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components {
    public class GroundColliderComponent : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private PlayerMovementComponent playerMovementComponent;

        #endregion


        #region Collision Checks

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerMovementComponent.IsGrounded = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            playerMovementComponent.IsGrounded = false;
        }

        #endregion
    }
}
