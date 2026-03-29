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
           
        }

        public override void HandleInput()
        {
            if (!fsm.Grounded.IsGrounded) { return; } // On est en l'air → pas d'action sol
            _moveInput = fsm.Inputs.GetMove();
            _isMoving = _moveInput.sqrMagnitude > 0.01f;
        }
        
        public override void FixedUpdate()
        {
            
        }
        
        public override void Update()
        {
            Vector2 moveInput = fsm.MoveInput;
            bool HasInput = moveInput.sqrMagnitude > 0.01f;
            
            // Quand on s'arrete  → Idle - When we stop -> idle
            if (!HasInput)
            {
                fsm.ChangeState(fsm._idleState);
                return;
            }
            
            if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState);
                return;
            }
            // Else stay in Move - Dynamic Animation
            fsm.Move.Move();
            fsm.headBob.IsMoving = true;
            fsm.headBob.MoveAmount = moveInput.magnitude;
            fsm.animator.SetFloat("X", moveInput.y);
            fsm.animator.SetFloat("Y", moveInput.x);
        }
        
        public override void Exit()
        {
            fsm.SetAuthority(PlayerMovementAuthority.None);
            fsm.animator.SetFloat("X", 0);
            fsm.animator.SetFloat("Y", 0);
            fsm.headBob.IsMoving = false;
        }
    }
}
