using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace PhysicPlayer
{
    public class Gravity : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Gravity")]
        [SerializeField, Range(-20f, 0f)] float _gravityValue;
        //PRIVATE
        private CharacterController _characterController;
        private Vector3 _gravityVelocity;
        private float _verticalVelocity;
        //PUBLIC
        public static Gravity Instance;
        public float GravityValue { get => _gravityValue;  set => _gravityValue = value; }
        #endregion
        #region Default Informations
        void Reset()
        {
            _gravityValue = -9.81f;
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            Instance = this;
            _characterController = GetComponentInParent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogError("CharacterController introuvable dans les parents !");
            }
        }
        
        // Update is called once per frame
        void Update()
        {
            ApplyGravity();
            // Apply gravity
           
        }
        #endregion
        #region Methods

        void ApplyGravity()
        {
            if (_characterController == null) return;
            
            // Maintient le joueur légèrement collé au sol.
            // On ne remet pas la vitesse à -2 si le joueur monte.
            if (_characterController.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }

            // Appliquer la gravité
            _verticalVelocity += _gravityValue * Time.deltaTime;
            /*_gravityVelocity.y += _gravityValue * Time.deltaTime;*/

            // Appliquer le mouvement
            Vector3 verticalMove = Vector3.up * _verticalVelocity * Time.deltaTime;
            _characterController.Move(verticalMove);
            /*_characterController.Move(_gravityVelocity * Time.deltaTime);*/
        }
        
        public void SetVerticalVelocity(float velocity)
        {
            _verticalVelocity = velocity;
        }

        public float GetVerticalVelocity()
        {
            return _verticalVelocity;
        }
        #endregion
    }
}

