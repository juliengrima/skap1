using UnityEngine;

namespace Player.State
{
    public class PlayerAirborneState : PlayerStateBase
    {
        public PlayerAirborneState(PlayerStateMachine fsm) : base(fsm) {}

        public override void Enter()
        {
            
        }
        
        public override void Update()
        {
            /*// Dès que le joueur quitte le sol → on sort
            if (!fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime < 0.1f)
            {
                fsm.ChangeState(fsm._fallState);
            }
            else
            {
                fsm.ChangeState(fsm._idleState);
            }*/
        }

        public override void Exit()
        {
            
        }
    }
}
