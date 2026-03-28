using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace PhysicPlayer
{
    public class Grounded : MonoBehaviour
    {
        #region Fields
        [Header("Character_Fields")]
        [SerializeField] bool _isGrounded;
        [SerializeField] float _rayDistance;
        [SerializeField, Range(30, 60)] float _rotationXLimit;
        [Header("Layers Informations")]
        [SerializeField] LayerMask _layers;
        //Private
        private CharacterController _characterController;
        private Vector3 _rayStart;
        //Public
        public static Grounded Instance;

        public bool IsGrounded { get => _isGrounded; }
        public Vector3 RayStart { get => _rayStart; set => _rayStart = value; }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        private void Reset()
        {
            _isGrounded = false;
            _rayDistance = 0.3f;
            //_player = transform.parent.GetComponentInChildren<Rigidbody>();
        }

        // Update is called once per frame

        #endregion
        #region Unity LifeCycle
        void Awake()
        {
            Instance = this;
        }
        
        void Start()
        {
            _characterController = GetComponentInParent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogError("CharacterController introuvable dans les parents !");
            }
        }

        #endregion
        #region Methods
        private void Update()
        {
            //IsGroundedGravity();
            GroundedRaycast();
        }

        private void GroundedRaycast()
        {
            // Assurez-vous que la valeur Y est légèrement au-dessus du sol
            //Make sure Y value is is slightly above the ground
            _rayStart = transform.position;
            // Lance un rayon vers le bas
            //Make Ray DownWard
            
            if (Physics.Raycast(_rayStart, Vector3.down, out RaycastHit hit, _rayDistance, _layers))
            {
                //Debug.Log($"Objet touché : {hit.collider.tag}");
                    _isGrounded = true;
                    // Ray is Green
                    Debug.DrawRay(_rayStart, Vector3.down * _rayDistance, Color.green);
            }
            else
            {
                _isGrounded = false;
                Debug.DrawRay(_rayStart, Vector3.down * _rayDistance, Color.red);
            }
        }

        void IsGroundedGravity()
        {
            // take info grounded's characterController
            _isGrounded = _characterController.isGrounded;
        }
        #endregion
    }
}