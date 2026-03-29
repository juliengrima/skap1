using UnityEngine;
using PhysicPlayer;
using Manager;
//using Entities;
using Player;

namespace Player.State
{
    public abstract class PlayerStateBase: IPlayerState
    {
        protected PlayerStateMachine fsm;
        protected InputsManager Inputs => fsm.Inputs;
        //protected CharacterController CharacterController => fsm.CharController;
        protected Grounded Grounded => fsm.Grounded;
       // protected JumpController Jump => fsm.Jump;
        protected MoveController Move => fsm.Move;
       // protected ScreenFaderManager ScreenFaderManager => fsm.ScreenFaderManager;
        protected Animator Animator => fsm.animator;
        
        protected PlayerStateBase(PlayerStateMachine fsm)
        {
            this.fsm = fsm;
        }

        public virtual void Enter()
        {
            //Debugs a supprimer une fois tout le state ok
            Debug.Assert(Inputs != null, "Input NOT injected");
            Debug.Assert(Grounded != null, "Grounded NOT injected");
            //Debug.Assert(Jump != null, "Jump NOT injected");
            Debug.Assert(Move != null, "Move NOT injected");
        }

        public virtual void HandleInput() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        
        public virtual void Exit() {}
    }
}
