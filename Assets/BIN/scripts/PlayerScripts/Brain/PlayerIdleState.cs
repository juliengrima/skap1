using UnityEngine;

namespace Player.State
{
    public class PlayerIdleState : PlayerStateBase
    {
        //Constructor
        public PlayerIdleState(PlayerStateMachine fsm) : base(fsm) {}

        public override void Enter()
        {
            //animator.SetMoving(false);
        }
        
        public override void HandleInput()
        {
            // if (fsm.Inputs.GetMove().sqrMagnitude > 0.01f && fsm.Grounded.IsGrounded)
            if (fsm.Inputs.GetMove().sqrMagnitude > 0.01f)
            {
                fsm.ChangeState(new PlayerMoveState(fsm));
                return;
            }

            // if (fsm.Inputs.GetJump() && fsm.Grounded.IsGrounded)
            /*if (fsm.Inputs.GetJump())
            {
                fsm.ChangeState(new PlayerJumpChargeState(fsm));
                return;
            }*/
        }

        public override void Update()
        {
            /*if (!fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime <= 0f)
            if (!fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime <= 0f)
            {
                fsm.ChangeState(fsm._fallState);
            }*/
        }

        public override void Exit() {}
    }
}
