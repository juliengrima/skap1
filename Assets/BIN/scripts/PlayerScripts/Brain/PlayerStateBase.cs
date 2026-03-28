using UnityEngine;
//using Physic;
using Manager;
//using Entities;
using Player;

namespace Player.State
{
    public abstract class PlayerStateBase: IPlayerState
    {
        protected PlayerStateMachine fsm;
        protected InputsManager Inputs => fsm.Inputs;
        protected Rigidbody Rb => fsm.Rb;
        protected Grounded Grounded => fsm.Grounded;
        /*protected JumpController Jump => fsm.Jump;
        protected MoveController Move => fsm.Move;
        protected ScreenFaderManager ScreenFaderManager => fsm.ScreenFaderManager;*/
        // protected Animator Animator => fsm.Animator;
        
        protected PlayerStateBase(PlayerStateMachine fsm)
        {
            this.fsm = fsm;

            //Debugs a supprimer une fois tout le state ok
            // Debug.Assert(_inputs != null, "Input NOT injected");
            // Debug.Assert(_grounded != null, "Grounded NOT injected");
            // Debug.Assert(_jump != null, "Jump NOT injected");
            // Debug.Assert(_rb != null, "Rb NOT injected");
            // Debug.Assert(_move != null, "Move NOT injected");
        }
        
        public virtual void Enter() {}

        public virtual void HandleInput() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        
        public virtual void Exit() {}
    }
}
