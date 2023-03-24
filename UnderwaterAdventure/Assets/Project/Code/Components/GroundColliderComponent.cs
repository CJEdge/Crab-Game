using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components {
    public class GroundColliderComponent : MonoBehaviour
    {
        #region Properties

        public int CurrentCollisions {
            get;
            set;
        }

        public bool IsGrounded {
            get {
                return this.CurrentCollisions >= 1;
            }
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
    }
}
