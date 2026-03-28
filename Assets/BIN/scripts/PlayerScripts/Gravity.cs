using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Player
{
    public class Gravity : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("CharacterController")]
        [Header("Gravity")]
        [SerializeField, Range(-20f, 0f)] float _gravityValue;
        //PRIVATE
        CharacterController _characterController;
        private Vector3 _gravityVelocity;
        //PUBLIC
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
            
        }
        void Start()
        {
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
            if (_characterController.isGrounded && _gravityVelocity.y < 0)
            {
                _gravityVelocity.y = -2f; 
                // petit "stick to ground" pour éviter les micro-sauts
            }

            // Appliquer la gravité
            _gravityVelocity.y += _gravityValue * Time.deltaTime;

            // Appliquer le mouvement
            _characterController.Move(_gravityVelocity * Time.deltaTime);
        }
        #endregion
    }
}

