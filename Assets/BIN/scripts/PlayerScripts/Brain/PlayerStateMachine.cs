using UnityEngine;
using PhysicPlayer;
using Manager;
using Cameras;


namespace Player.State
{
    public class PlayerStateMachine : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Controllers")]
        [SerializeField] MoveController _move;
        /*[SerializeField] JumpController _jump;*/
        [Header("Player Animation")]
        [SerializeField] Animator _animator;
        [Header("Player Camera animation")]
        [SerializeField] HeadBob _headBob;
        //PRIVATE
        private IPlayerState _currentState;
        private PlayerMovementAuthority _authority;
        private InputsManager _inputs;
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
        private PlayerDeathState _deathState { get; set; }
        
        // FSM CONTROLLERS
        public InputsManager Inputs { get => _inputs; set => _inputs = value; }
        //public CharacterController CharController { get => _characterController; set => _characterController = value; }
        public Grounded Grounded { get => _grounded; set => _grounded = value; }
        public MoveController Move { get => _move; set => _move = value; }
        /*public JumpController Jump { get => _jump; set => _jump = value; }*/
        public Animator animator { get => _animator; set => _animator = value; }
        public HeadBob headBob { get => _headBob; }
        //FSM VARIABLES
        public Vector2 MoveInput { get; private set; }

        /*public ScreenFaderManager ScreenFaderManager { get => _screenFaderManager; set => _screenFaderManager = value; }*/
        #endregion
        /*#region Enumerator
        public enum PlayerState
        {
            Idle,
            Charge,
            Jump,
            Roll,
            Death
        }
        #endregion*/
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            Instance = this;
            _inputs = InputsManager.Instance;
            _grounded = Grounded.Instance;
            //_jump = JumpController.Instance;
            //_screenFaderManager = ScreenFaderManager.Instance;
            
            if (_move == null)
                _move = GetComponentInChildren<MoveController>();
            
            _idleState = new PlayerIdleState(this);
            _airborneState = new PlayerAirborneState(this);
            _fallState = new PlayerFallState(this);
            _moveState = new PlayerMoveState(this);
            _jumpState = new PlayerJumpState(this);
            _deathState = new PlayerDeathState(this);
        }
        void Start()
        { 
            //_characterController = GetComponentInParent<CharacterController>();
            HealthManager.Instance.OnDeath += HandleDeath;
            ChangeState(_idleState);
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log($"STATE={CurrentState} AUTH={Authority}");
            MoveInput = Inputs.GetMove();
            
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
        
        void HandleDeath()
        {
            ChangeState(_deathState);
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