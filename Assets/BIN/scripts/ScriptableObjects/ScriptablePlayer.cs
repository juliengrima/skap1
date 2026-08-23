using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "ScriptablePlayer", menuName = "Scriptable Objects/ScriptablePlayer")]
    public class ScriptablePlayer : ScriptableObject
    {
        //INSPECTOR
        // Environnement
        /*[SerializeField] float _temperature;
        [SerializeField] float _minTemperature;
        [SerializeField] float _maxTemperature;
        [SerializeField] float _nominalTemperature;
        [SerializeField] float _temperatureRecoverySpeed;*/
        // Health
        [SerializeField] float _life;
        [SerializeField] float _startLife;
        // Jumping
        [SerializeField] float _jumpForce;
        [SerializeField] float _boostVelocity;
        [SerializeField] float _boostDuration;
        // Moving
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotationSpeed;
        //PRIVATE
        //PUBLIC
        public float Life { get => _life;  set => _life = value; }
        public float StartLife { get => _startLife;  set => _startLife = value; }
        public float JumpForce { get => _jumpForce;  set => _jumpForce = value; }
        public float BoostVelocity { get => _boostVelocity; set => _boostVelocity = value; }
        public float BoostDuration { get => _boostDuration; set => _boostDuration = value; }
        public float MoveSpeed { get => _moveSpeed;  set => _moveSpeed = value; }
        public float RotationSpeed { get => _rotationSpeed; }
    }
}
