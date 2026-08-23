using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using Player;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace PhysicPlayer
{
    public class JumpController : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Informations")]
        [SerializeField] ScriptablePlayer _player;
        [Header("Jump Informations")]
        [SerializeField] float _jumpDamage;
        //PRIVATE
        private CharacterController _characterController;
        private Gravity _gravity;
        private Grounded _grounded;
        private float _boostTimer;
        //PUBLIC
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            _characterController = GetComponentInParent<CharacterController>();

            if (_characterController == null)
                Debug.LogError("CharacterController introuvable dans les parents.");
        }

        void Start()
        {
            _gravity = Gravity.Instance;
            _grounded = Grounded.Instance;
        }
        #endregion
        #region Methods
        public void StartBoost()
        {
            if (_characterController == null || _gravity == null) return;
            if (!_characterController.isGrounded) return;

            _boostTimer = _player.BoostDuration;
            _gravity.SetVerticalVelocity(_player.BoostVelocity);
        }
        
        public void UpdateBoost(bool jumpHeld)
        {
            if (_boostTimer <= 0f || !jumpHeld) return;

            _boostTimer -= Time.deltaTime;

            // Maintient l'élan vers le haut tant que le bouton est maintenu.
            _gravity.SetVerticalVelocity(_player.BoostVelocity);
        }
        public void PerformJump()
        {
            if (_characterController == null || _gravity == null || _player == null) return;
            if (!_characterController.isGrounded) return;
            
            float jumpVelocity = Mathf.Sqrt(
                _player.JumpForce *
                -2f *
                _gravity.GravityValue
            );

            _gravity.SetVerticalVelocity(jumpVelocity);

            Debug.Log("JUMP EXECUTE");
        }
        #endregion
    }
}
