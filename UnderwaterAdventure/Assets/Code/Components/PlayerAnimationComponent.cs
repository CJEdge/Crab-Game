using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class PlayerAnimationComponent : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Animator anim;

        [SerializeField]
        private PlayerMovementComponent pmc;

        #endregion


        #region Types

        public enum ClawState
        {
            Crab_Claw_Idle,
            Crab_Claw_Side_Attack,
            Crab_Claw_Up_Attack,
            Crab_Claw_Down_Attack
        };

        public ClawState clawState;

        public enum HeadState
        {
            Crab_Head_Idle,
            Crab_Head_Jump,
            Crab_Head_Down_Attack
        };

        public HeadState headState;

        #endregion


        #region MonoBehaviours

        public void Update()
        {
            if (pmc == null)
            {
                return;
            }
            SetHeadAnimation();
            SetClawAnimation();
        }

        #endregion


        #region Private Methods

        private void SetHeadAnimation()
        {
            //IDLE
            if (pmc.IsGrounded && !pmc.IsSDownAttacking)
            {
                headState = HeadState.Crab_Head_Idle;
            } 
            //JUMP
            else if (!pmc.IsGrounded && !pmc.IsSDownAttacking)
            {
                headState = HeadState.Crab_Head_Jump;
            }
            //DOWN ATTACK
            else if (pmc.IsSDownAttacking)
            {
                headState = HeadState.Crab_Head_Down_Attack;
                pmc.IsSDownAttacking = true;
            }

            anim.Play(headState.ToString());
        }

        private void SetClawAnimation()
        {
            //IDLE
            if (!pmc.IsSideAttacking && !pmc.IsUpAttacking && !pmc.IsSDownAttacking)
            {
                clawState = ClawState.Crab_Claw_Idle; 
            } 
            //SIDE ATTACK
            else if( pmc.IsSideAttacking && !pmc.IsUpAttacking && !pmc.IsSDownAttacking)
            {
                clawState = ClawState.Crab_Claw_Side_Attack;
            } 
            //UP ATTACK
            else if(pmc.IsUpAttacking && !pmc.IsSideAttacking && !pmc.IsSDownAttacking)
            {
                clawState = ClawState.Crab_Claw_Up_Attack;
            }
            //DOWN ATTACK
            else if(pmc.IsSDownAttacking && !pmc.IsUpAttacking && !pmc.IsSideAttacking)
            {
                clawState = ClawState.Crab_Claw_Down_Attack;
                pmc.IsSDownAttacking = true;
            }

            anim.Play(clawState.ToString());
        }

        #endregion
    }
}
