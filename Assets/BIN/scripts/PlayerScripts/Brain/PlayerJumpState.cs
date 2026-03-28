namespace Player.State
{
    public class PlayerJumpState : PlayerStateBase
    {
        private bool _jumpApplied;
        
        //Constructor
        public PlayerJumpState(PlayerStateMachine fsm) : base(fsm) {}
        
        public override void Enter()
        {
            fsm.SetAuthority(PlayerMovementAuthority.Jump);
            _jumpApplied = false;
        }

        public override void FixedUpdate()
        {
            if (_jumpApplied) return;
            
           // fsm.Jump.PerformJump();
            _jumpApplied = true;
        }
        
        public override void Update()
        {
            if (!_jumpApplied) return;
            /*if (fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime > 0.1f)
            {
                fsm.ChangeState(fsm._idleState);
            }
            else if (!fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime <= 0f)
            {
                fsm.ChangeState(fsm._fallState);
            }*/
        }
        
        public override void Exit()
        {
            fsm.SetAuthority(PlayerMovementAuthority.None);
            //fsm.Jump.ResetCharge(); // Reset Sécurity
        }
    }
}
