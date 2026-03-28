using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using Player.State;
using PhysicPlayer;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Player
{
    public class MoveController : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Movement")]
        [SerializeField] ScriptablePlayer _player;
        [SerializeField] Transform _playerTransform;
        [Header("Hit_Damage_Health")]
        [SerializeField] float _moveDamagePerSecond;
        [Header("Timer Movement")]
        [SerializeField] float _moveDuration;
        [SerializeField] float _moveCooldown;
        //PRIVATE
        private InputsManager _inputs;
        private PlayerStateMachine _playerStateMachine;
        private Grounded _grounded;
        //private AudioManager _audioManager;
        //private HealthManager _healthManager;
        private Vector3 _moveInput;
        private float _moveTimeRemaining;
        private float _damagePerSecond;
        // PUBLIC
        //PRIVATE
        CharacterController _characterController;
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            _moveDamagePerSecond = 0.02f;
            _moveDuration = 0.5f;
            _moveCooldown = 20f;
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            
        }
        void Start()
        {
            _characterController = GetComponentInParent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogError("CharacterController introuvable dans les parents !");
            }
            
            _playerStateMachine = PlayerStateMachine.Instance;
            _inputs = InputsManager.Instance;
            _grounded = Grounded.Instance;
            
            /*_audioManager = AudioManager.Instance;
            _healthManager = HealthManager.Instance;
            _speed = _player.MoveSpeed;
            _moveDuration = _player.MoveDuration;*/

            if (_moveDamagePerSecond == 0) _moveDamagePerSecond = 0.02f;
            if (_moveCooldown == 0) _moveCooldown = 20f;
            if (_moveDuration == 0) _moveDuration = 0.5f;
        }
        // Update is called once per frame
        void Update()
        {
            Move();
        }
        #endregion
        #region Methods

        void Move()
        {
            if (_characterController == null) return;
            
            Vector2 input = _inputs.GetMove();
            
            // 🔄 Rotation (Q/D, flèches, stick gauche X)
            float rotationInput = input.x;
            float rotation = rotationInput * _player.RotationSpeed * Time.deltaTime;
            _playerTransform.Rotate(Vector3.up, rotation);

            // ⬆️⬇️ Déplacement (Z/S, flèches, stick gauche Y)
            float moveInput = input.y;
            Vector3 move = _playerTransform.forward * moveInput * _player.MoveSpeed;

            // Application
            _characterController.Move(move * Time.deltaTime);
            
            Moving();
        }
        void Moving()
        {
            //Déplacement perte de PV - Movement loss of HP
            /*_healthManager.TakeDamage(Time.fixedDeltaTime * (_moveDamagePerSecond + _damagePerSecond));
            _damagePerSecond = 0f;*/
        }
        void LateUpdate()
        {
            
        }
        #endregion

    }
}
