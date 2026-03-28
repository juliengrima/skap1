using UnityEngine;
using Manager;

namespace Player.State
{
    public class PlayerDeathState : PlayerStateBase
    {
        /*private CoroutineManager _coroutineManager;
        private ScreenFaderManager _screenFaderManager;*/
        public PlayerDeathState(PlayerStateMachine fsm) : base(fsm) {}

        public override void Enter()
        {
            /*fsm.Move.OnDisable();
            fsm.Jump.OnDisable();*/
            // Death Animation
            /*ScreenFaderManager.Instance?.FadeIn();*/
        }
        public override void HandleInput() {}

        public override void Update(){}
        public override void FixedUpdate(){}
        public override void Exit(){}
        
    }
}
