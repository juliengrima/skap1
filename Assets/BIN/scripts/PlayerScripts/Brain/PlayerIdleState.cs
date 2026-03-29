using UnityEngine;

namespace Player.State
{
    public class PlayerIdleState : PlayerStateBase
    {
        //Constructor
        public PlayerIdleState(PlayerStateMachine fsm) : base(fsm) {}

        public override void Enter()
        {
            fsm.animator.SetFloat("X", 0);
        }
        
        public override void HandleInput()
        {
            if (fsm.Grounded.IsGrounded && fsm.Inputs.GetMove().sqrMagnitude > 0.01f)
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
            
            if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState);
                return;
            }
        }

        public override void Update()
        {
           
        }

        public override void Exit() {}
    }
}
