using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace CameraUI
{
    public class Compass : MonoBehaviour
    {
        #region Champs
        //INSPECTOR
        [Header("References")]
        [SerializeField] Transform _player;
        
        [Header("UI")]
        [SerializeField] RectTransform _compassRoot;
        [SerializeField] RawImage _ticksLine; // texture répétée
        [SerializeField] RectTransform _cardinalsParent;
        [SerializeField] RectTransform _markersParent;

        [Header("Settings")]
        [SerializeField] float _compassWidth;
        [SerializeField] float _scrollSpeed;

        [Header("Cardinals")]
        [SerializeField] GameObject _cardinalPrefab;
        [SerializeField] Sprite[] _cardinalSprites; // N E S W

        [Header("Markers")]
        [SerializeField] List<Transform> _targets;
        [SerializeField] GameObject _markerPrefab;
        //PRIVATE
        private List<RectTransform> _cardinals = new();
        private List<RectTransform> _markers = new();
        //PUBLIC
        #endregion
        #region Default Informations
        void Reset()
        {
            _compassWidth = 600f;
            _scrollSpeed = 1f;
        }
        #endregion
        #region Unity LifeCycle
        // Start is called before the first frame update
        
        void Awake()
        {
            
        }
        void Start()
        {
            SetupCardinals();
            SetupMarkers();
        }
            
        // Update is called once per frame
        void Update()
        {
            float yaw = _player.eulerAngles.y;

            UpdateTicks(yaw);
            UpdateCardinals(yaw);
            UpdateMarkers(yaw);
        }
        #endregion
        #region TICKS
        void UpdateTicks(float yaw)
        {
            // Scroll texture (UV offset)
            float offset = yaw / 360f * _scrollSpeed;
            _ticksLine.uvRect = new Rect(offset, 0, 1, 1);
        }
        #endregion

        #region CARDINALS
        void SetupCardinals()
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject go = Instantiate(_cardinalPrefab, _cardinalsParent);
                go.GetComponent<Image>().sprite = _cardinalSprites[i];
                _cardinals.Add(go.GetComponent<RectTransform>());
            }
        }

        void UpdateCardinals(float yaw)
        {
            for (int i = 0; i < _cardinals.Count; i++)
            {
                float angle = i * 90f;
                float offset = Mathf.DeltaAngle(yaw, angle);

                float x = (offset / 180f) * (_compassWidth / 2f);

                _cardinals[i].anchoredPosition = new Vector2(x, 0);
            }
        }
        #endregion

        #region MARKERS
        void SetupMarkers()
        {
            foreach (var t in _targets)
            {
                GameObject go = Instantiate(_markerPrefab, _markersParent);
                _markers.Add(go.GetComponent<RectTransform>());
            }
        }

        void UpdateMarkers(float yaw)
        {
            int count = Mathf.Min(_targets.Count, _markers.Count);

            for (int i = 0; i < count; i++)
            {
                Vector3 dir = _targets[i].position - _player.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

                float offset = Mathf.DeltaAngle(yaw, angle);
                float x = (offset / 180f) * (_compassWidth / 2f);

                _markers[i].anchoredPosition = new Vector2(x, 0);

                // Optionnel : cacher hors champ
                _markers[i].gameObject.SetActive(Mathf.Abs(offset) < 90f);
            }
        }
        #endregion
    }
}
