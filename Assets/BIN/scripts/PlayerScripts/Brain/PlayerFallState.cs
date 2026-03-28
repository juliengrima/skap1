namespace Player.State
{
    public class PlayerFallState : PlayerStateBase
    {
        public PlayerFallState(PlayerStateMachine fsm) : base(fsm) {}
        
        public override void Enter() {}
        
        public override void HandleInput() { }

        public override void Update()
        {
            /*if (fsm.Grounded.IsGrounded && fsm.Grounded.GroundedTime > 0.1f)
            {
                fsm.ChangeState(fsm._idleState); // ou Move si input
            }*/
        }

        public override void FixedUpdate() { }

        public override void Exit() {}
    }
}
