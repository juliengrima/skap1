using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Player;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Manager
{
    public class UIBarsManager : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("Player Informations")]
        [SerializeField] ScriptablePlayer _player;
        [Header("Bars Informations")]
        [SerializeField] Image _healthbar;
        //PRIVATE
        private HealthManager _healthManager;
        //PUBLIC
        public static UIBarsManager Instance;
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
            Instance = this;
        }

        private void Start()
        {
            _healthManager = HealthManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateHealthBar();
        }
        #endregion
        #region Methods
        public void UpdateHealthBar()
        {
            if (_healthbar != null)
            {
                // Mise à jour de la barre de vie en fonction de la santé actuelle
                float targetFillAmount = _player.Life / _player.StartLife;
                _healthbar.fillAmount = targetFillAmount;

                // Mise à jour des textes de santé
                //_currentHealthText.text = Mathf.CeilToInt(_scriptablePlayer.CurrentHealth).ToString();
                //_maxHealthText.text = Mathf.CeilToInt(_scriptablePlayer.MaxHealth).ToString();
            }
        }
        #endregion
    }
}
