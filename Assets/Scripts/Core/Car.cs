using System;
using Configuration;
using UnityEngine;

namespace Core
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private WheelJoint2D rareWheelJoint;
        [SerializeField] private WheelJoint2D frontWheelJoint;
        [SerializeField] private Rigidbody2D rearWheelRb;
        [SerializeField] private Rigidbody2D bodyRb;

        private GameConfig _config;

        private JointMotor2D _motor;

        public event Action DriverIsDead;

        public void Setup(GameConfig gameConfig)
        {
            _config = gameConfig;
            _motor = rareWheelJoint.motor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Road"))
                DriverIsDead?.Invoke();
        }

        public void Accelerate()
        {
            if (!rareWheelJoint.useMotor)
            {
                rareWheelJoint.useMotor = true;
                _motor.motorSpeed = rearWheelRb.angularVelocity;
                rareWheelJoint.motor = _motor;
            }

            ChangeMotorSpeed(-_config.DeltaForwardSpeed);
        }

        public void Brake()
        {
            if (bodyRb.velocity.sqrMagnitude > _config.MaxSlowDownSqrSpeed &&
                Vector3.Angle(bodyRb.velocity, Vector3.right) < 90)
            {
                rareWheelJoint.useMotor = true;
                _motor.motorSpeed = 0;
                rareWheelJoint.motor = _motor;

                frontWheelJoint.useMotor = true;
                _motor.motorSpeed = 0;
                frontWheelJoint.motor = _motor;
            }
            else
            {
                rareWheelJoint.useMotor = true;

                _motor.motorSpeed = rearWheelRb.angularVelocity;
                rareWheelJoint.motor = _motor;

                frontWheelJoint.useMotor = false;
                ChangeMotorSpeed(_config.DeltaRearSpeed);
            }
        }

        public void ReleasePedal()
        {
            frontWheelJoint.useMotor = false;
            rareWheelJoint.useMotor = false;
        }

        private void ChangeMotorSpeed(float delta)
        {
            _motor.motorSpeed += delta;
            rareWheelJoint.motor = _motor;
        }
    }
}