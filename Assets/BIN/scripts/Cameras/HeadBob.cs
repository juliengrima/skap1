using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Cameras
{
    public class HeadBob : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player HeadBob Camera ")]
        [SerializeField] float _bobFrequency;
        [SerializeField] float _bobAmplitude;
        [SerializeField] float _speedMultiplier;
        //PRIVATE
        Vector3 _startPos;
        float _timer;
        //PUBLIC
        public bool IsMoving { get; set; }
        public float MoveAmount { get; set; } // in
        #endregion
        #region Default Informations
        void Reset()
        {
            _bobFrequency = 8f;
            _bobAmplitude = 0.05f;
            _speedMultiplier = 1f;
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        void Start()
        {
            _startPos = transform.localPosition;
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsMoving)
            {
                _timer = 0;
                transform.localPosition = Vector3.Lerp(transform.localPosition, _startPos, Time.deltaTime * 5f);
                return;
            }

            _timer += Time.deltaTime * _bobFrequency * (MoveAmount * _speedMultiplier);

            float bobY = Mathf.Sin(_timer) * _bobAmplitude;
            float bobX = Mathf.Cos(_timer * 0.5f) * _bobAmplitude * 0.5f;

            transform.localPosition = _startPos + new Vector3(bobX, bobY, 0);
        }
        #endregion
    }
}
