using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager
{
    public class InputsManager : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Entities")]
        private InputSystem_Actions _playerInputs;
        //PRIVATE
        //PUBLIC
        public static InputsManager Instance;
        #endregion
        #region Unity LifeCycle
        void Awake()
        {
            Instance = this;
            _playerInputs = new InputSystem_Actions();
        }
        
        // Start is called before the first frame update
        void Start()
        {
        
        }
        #endregion
        #region EnableDisable
        public void OnEnable()
        {
            _playerInputs.Enable();
        }

        public void OnDisable()
        {
            _playerInputs.Disable();
        }

        #endregion
        #region Movements
        public Vector2 GetMove()
        {
            return _playerInputs.Player.Move.ReadValue<Vector2>();
        }
        #endregion
    }

}
