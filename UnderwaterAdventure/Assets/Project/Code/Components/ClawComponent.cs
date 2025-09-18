using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class ClawComponent : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float knockbackPower;

        [SerializeField]
        private PlayerAnimationComponent playerAnimationComponent;

        #endregion




        #region Collision Checks

        private void OnTriggerStay2D(Collider2D collision)
        {
            Rigidbody2D rb = collision.GetComponent<PhysicsBodyComponent>()?.rb;
            if (rb == null)
            {
                return;
            }
            Debug.Log("rigidbody found");
                switch (playerAnimationComponent.clawState)
            {
                case PlayerAnimationComponent.ClawState.Crab_Claw_Idle:
                    return;
                case PlayerAnimationComponent.ClawState.Crab_Claw_Side_Attack:
                    float direction = transform.position.x > collision.transform.position.x ? -1 : 1;
                    rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                    rb.AddForce(new Vector2(direction * knockbackPower, 0));
                    return;
                case PlayerAnimationComponent.ClawState.Crab_Claw_Up_Attack:
                    direction = transform.position.y > collision.transform.position.x ? -1 : 1;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    rb.AddForce(new Vector2(0, direction * knockbackPower/3));
                    return;
            }
        }

        #endregion

    }
}
