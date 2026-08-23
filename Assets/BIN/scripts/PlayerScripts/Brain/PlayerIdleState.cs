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
            if (fsm.Inputs.GetJumpPressed() && fsm.Grounded.IsGrounded)
            {
                /*fsm.ChangeState(new PlayerJumpState(fsm));*/
                fsm.ChangeState(fsm._jumpState);
                return;
            }
            
            if (fsm.Grounded.IsGrounded && fsm.Inputs.GetMove().sqrMagnitude > 0.01f)
            {
                fsm.ChangeState(fsm._moveState);
                return;
            }

            if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState);
            }
        }

        public override void Update()
        {
            if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState);
                return;
            }
        }

        public override void Exit() {}
    }
}
