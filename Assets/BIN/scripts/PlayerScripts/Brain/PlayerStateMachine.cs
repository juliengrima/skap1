using UnityEngine;
using PhysicPlayer;
using Manager;
//using Entities;
using Player;


namespace Player.State
{
    public class PlayerStateMachine : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Entities")]
        //PRIVATE
        private IPlayerState _currentState;
        private PlayerMovementAuthority _authority;
        private InputsManager _inputs;
        private Rigidbody _rb;
        /*private JumpController _jump;*/
        /*private MoveController _move;*/
        private Grounded _grounded;
        /*private ScreenFaderManager _screenFaderManager;*/
        //PUBLIC
        public static PlayerStateMachine Instance;
        public IPlayerState CurrentState { get => _currentState; set => _currentState = value; }
        public PlayerMovementAuthority Authority { get => _authority; set => _authority = value; }
        
        // FSM STATES
        public PlayerIdleState _idleState { get; private set; }
        public PlayerAirborneState _airborneState { get; private set; }
        public PlayerFallState _fallState { get; private set; }
        public PlayerMoveState _moveState { get; private set; }
        public PlayerJumpState _jumpState { get; private set; }
        public PlayerDeathState _deathState { get; private set; }
        
        // FSM CONTROLLERS
        public InputsManager Inputs { get => _inputs; set => _inputs = value; }
        public Rigidbody Rb { get => _rb; set => _rb = value; }
        /*public JumpController Jump { get => _jump; set => _jump = value; }*/
        public Grounded Grounded { get => _grounded; set => _grounded = value; }
        /*public MoveController Move { get => _move; set => _move = value; }*/
        /*public ScreenFaderManager ScreenFaderManager { get => _screenFaderManager; set => _screenFaderManager = value; }*/
        #endregion
        #region Enumerator
        public enum PlayerState
        {
            Idle,
            Charge,
            Jump,
            Roll,
            Death
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            Instance = this;
            
            _idleState = new PlayerIdleState(this);
            _airborneState = new PlayerAirborneState(this);
            _fallState = new PlayerFallState(this);
            _moveState = new PlayerMoveState(this);
            _jumpState = new PlayerJumpState(this);
            _deathState = new PlayerDeathState(this);
        }
        void Start()
        { 
            _inputs = InputsManager.Instance;
            _grounded = Grounded.Instance;
            //_jump = JumpController.Instance;
            //_move = MoveController.Instance;
            //_screenFaderManager = ScreenFaderManager.Instance;
            
            _rb = GetComponentInParent<Rigidbody>();
            //_jump.OnEnable();
            //_move.OnEnable();

            ChangeState(_idleState);
        }

        // Update is called once per frame
        void Update()
        {
            // Debug.Log($"STATE={CurrentState} AUTH={Authority}");
            _currentState?.HandleInput();
            _currentState?.Update();
        }
        #endregion
        #region Methods
        void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }
        
        public void SetAuthority(PlayerMovementAuthority authority)
        {
            _authority = authority;
        }
        #endregion
        #region StatesMachine
        public void ChangeState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        #endregion
    }
}