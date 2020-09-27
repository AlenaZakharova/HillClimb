using System;
using Configuration;
using UnityEngine;

namespace Core
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private WheelJoint2D rareWheelJoint;
        [SerializeField] private Rigidbody2D rearWheelRB;
        [SerializeField] private Collider driverCollider;

        private GameConfig _config;
        private bool _raceStarted;
        private bool _accelerate;
        private bool _brake;
        private JointMotor2D _motor;

        public event Action DriverIsDead;

        public void Setup(GameConfig gameConfig)
        {
            _config = gameConfig;
            _motor = rareWheelJoint.motor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag($"Road"))
                DriverIsDead?.Invoke(); 
        }

        public void StartRace()
        {
            _raceStarted = true;
        }

        public void StopRace()
        {
            _raceStarted = false;
        }

        public void Accelerate()
        {
            _accelerate = true;
            if (!rareWheelJoint.useMotor)
            {
                rareWheelJoint.useMotor = true;
                _motor.motorSpeed = rearWheelRB.angularVelocity;
                rareWheelJoint.motor = _motor;
            }

            ChangeMotorSpeed(-_config.DeltaForwardSpeed);
        }

        public void Brake()
        {
            _brake = true;
            if (!rareWheelJoint.useMotor)
            {
                rareWheelJoint.useMotor = true;
                _motor.motorSpeed = rearWheelRB.angularVelocity;
                rareWheelJoint.motor = _motor;
            }

            ChangeMotorSpeed(_config.DeltaRearSpeed);
        }

        public void ReleasePedal()
        {
            rareWheelJoint.useMotor = false;
        }

        private void ChangeMotorSpeed(float delta)
        {
            _motor.motorSpeed += delta;
            rareWheelJoint.motor = _motor;
        }
    }
}