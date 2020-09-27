using Configuration;
using UnityEngine;

namespace Core
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private WheelJoint2D rareWheelJoint;

        private GameConfig _config;
        private bool _raceStarted;
        
        public void Setup(GameConfig gameConfig)
        {
            _config = gameConfig;
        }

        private void Update()
        {
            
        }

        public void StartRace()
        {
            _raceStarted = true;
            rareWheelJoint.useMotor = true;
            var motor = rareWheelJoint.motor;
            motor.motorSpeed = -500;
            rareWheelJoint.motor = motor;
        }

        public void StopRace()
        {
            _raceStarted = false;
        }

        public void Move()
        {
           
        }

        public void Brake()
        {
        }
    }
}