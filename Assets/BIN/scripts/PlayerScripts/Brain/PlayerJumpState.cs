namespace Player.State
{
    public class PlayerJumpState : PlayerStateBase
    {
        private bool _jumpApplied;
        
        //Constructor
        public PlayerJumpState(PlayerStateMachine fsm) : base(fsm) {}
        
        public override void Enter()
        {
            base.Enter();
            fsm.SetAuthority(PlayerMovementAuthority.Jump);
            _jumpApplied = false;
            
            /*if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState);
                return;
            }*/
            
            fsm.Jump.PerformJump();
            _jumpApplied = true;
        }
        
        public override void Update()
        {
            if (!_jumpApplied) return;
            
            // Le personnage vient de quitter le sol.
            if (!fsm.Grounded.IsGrounded)
            {
                fsm.ChangeState(fsm._fallState); 
                
            }
        }
        
        public override void Exit()
        {
            fsm.SetAuthority(PlayerMovementAuthority.None);
        }
    }
}
