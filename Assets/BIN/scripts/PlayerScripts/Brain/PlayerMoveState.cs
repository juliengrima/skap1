using UnityEngine;

namespace Player.State
{
    public class PlayerMoveState : PlayerStateBase
    {
        private bool _isMoving;
        private Vector2 _moveInput;
        private Vector3 _moveDirection;
        
        public PlayerMoveState(PlayerStateMachine fsm) : base(fsm) {}
        
        public override void Enter()
        {
            fsm.SetAuthority(PlayerMovementAuthority.Move);
            //fsm.Move.StartMove();
        }

        public override void HandleInput()
        {
            if (!fsm.Grounded.IsGrounded) { return; } // On est en l'air → pas d'action sol
            _moveInput = fsm.Inputs.GetMove();
            _isMoving = fsm.Grounded.IsGrounded && _moveInput.sqrMagnitude > 0.01f;
        }
        
        public override void FixedUpdate()
        {
            if (!_isMoving) return;
            _moveDirection = new Vector3(_moveInput.x, 0f, _moveInput.y);
           // fsm.Move.Moving(_moveDirection);
        }
        
        public override void Update()
        {
            /*bool HasInput = fsm.Inputs.GetMove().sqrMagnitude > 0.01f;
            bool IsSlidingInvoluntary = fsm.Grounded.IsGrounded && fsm.Grounded.IsOnSlope && !HasInput;
            bool IsSlidingVoluntary = fsm.Grounded.IsGrounded && fsm.Grounded.IsOnSlope && HasInput;
            
            if (!fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime <= 0f)
            {
                fsm.ChangeState(fsm._fallState);
            }*/
            
            // Quand on s'arrete  → Idle - When we stop -> idle
            /*if (fsm.Grounded.IsGrounded && !HasInput)
            {
                // fsm.Jump.IsJumping = false;
                fsm.ChangeState(fsm._idleState);
            }
            else if ((fsm.Grounded.IsGrounded && IsSlidingInvoluntary))
            {
                fsm.Jump.IsJumping = false;
                fsm.ChangeState(fsm._idleState);
            }
            
            if (fsm.Grounded.IsGrounded && fsm.Inputs.GetJump())
            {
                fsm.Jump.IsJumping = false;
                fsm.ChangeState(fsm._jumpChargeState);
            }*/
        }
        
        public override void Exit()
        {
            fsm.SetAuthority(PlayerMovementAuthority.None);
        }
    }
}
