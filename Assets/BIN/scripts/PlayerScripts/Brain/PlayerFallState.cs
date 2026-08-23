namespace Player.State
{
    public class PlayerFallState : PlayerStateBase
    {
        public PlayerFallState(PlayerStateMachine fsm) : base(fsm) {}
        
        public override void Enter() {}
        
        public override void HandleInput() { }

        public override void Update()
        {
            if (fsm.Grounded.IsGrounded)
            {
                if (fsm.Inputs.GetMove().sqrMagnitude > 0.01f)
                {
                    fsm.ChangeState(fsm._moveState);
                }
                else
                {
                    fsm.ChangeState(fsm._idleState);
                }
            }
        }

        public override void FixedUpdate() { }

        public override void Exit() {}
    }
}
