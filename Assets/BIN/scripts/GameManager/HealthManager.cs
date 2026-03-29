using Player;
using UnityEngine;
using UnityEngine.Events;


namespace Manager
{
    public class HealthManager : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Entities")]
        [Header("Player Settings")]
        [SerializeField] ScriptablePlayer _player;
        //PRIVATE
        
        //private AudioManager _audioManager;
        //private PlayerStateMachine _fsm;
        //PUBLIC
        public static HealthManager Instance;
        public event System.Action OnDeath;
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            Instance = this;
           // _audioManager = AudioManager.Instance;
        }

        // Update is called once per frame
        #endregion
        #region Methods
        public void TakeDamage(float damage)
        {
            _player.Life -= damage;
            // Debug.Log($"TakeDamage = {_player.Life}");
            // _hitEvent.Invoke();
            // _audioManager?.PlayerTakeDamage();

            if (_player.Life <= 0)
            {
                _player.Life = 0;
                Debug.Log("Player is dead");
                OnDeath?.Invoke();
            }
        }
        #endregion
    }
}
