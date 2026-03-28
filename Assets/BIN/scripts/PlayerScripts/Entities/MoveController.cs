using System;
using System.Collections;
using System.Collections.Generic;
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
    public class Mov : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Movement")]
        //[SerializeField] ScriptablePlayer _player;
        [SerializeField] float _smoothSpeed;
        [SerializeField] float _gravitySpeed;
        [Header("Ground_Damage_Movement")]
        [SerializeField] float _surfaceMultiplier;
        [Header("Hit_Damage_Health")]
        [SerializeField] float _moveDamagePerSecond;
        [Header("Timer Movement")]
        [SerializeField] float _moveDuration;
        [SerializeField] float _moveCooldown;
        //PRIVATE
        //private AudioManager _audioManager;
        private Rigidbody _rb;
        private Camera _camera;
        private PlayerStateMachine _playerStateMachine;
        private Grounded _grounded;
        //private HealthManager _healthManager;
        private Vector3 _moveInput;
        private Vector3 _movement;
        private float _speed;
        private float _moveTimeRemaining;
        private float _damagePerSecond;
        private bool _canMove;
        private bool _isMoving;
        // PUBLIC
        //PRIVATE
        CharacterController _characterController;
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            
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
            
            //_audioManager = AudioManager.Instance;
            _grounded = Grounded.Instance;
            //_healthManager = HealthManager.Instance;
            /*_speed = _player.MoveSpeed;
            _moveDuration = _player.MoveDuration;*/

            if (_moveDamagePerSecond == 0) _moveDamagePerSecond = 0.02f;
            if (_smoothSpeed == 0) _smoothSpeed = 0.5f;
            if (_surfaceMultiplier == 0) _surfaceMultiplier = 1f;
            if (_gravitySpeed == 0) _gravitySpeed = 0.3f;
            if (_moveCooldown == 0) _moveCooldown = 20f;
            if (_moveDuration == 0) _moveDuration = 0.5f;
            if (!_canMove) _canMove = true;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        #endregion
        #region Methods
        void FixedUpdate()
        {
            
        }
        void LateUpdate()
        {
            
        }
        #endregion

    }
}
