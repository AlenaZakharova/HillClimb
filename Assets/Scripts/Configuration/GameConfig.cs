using UnityEngine;
using Core;

namespace Configuration
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Header("Camera")] 
        [SerializeField] private float smoothTime;

        [Header("Car")]
        [SerializeField] private Car carPrefab;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private float engineForce;
        [SerializeField] private float brakeForce;


        public Car CarPrefab => carPrefab;

        public Vector3 StartPosition => startPosition;

        public float SmoothTime => smoothTime;


        public float EngineForce => engineForce;
        public float BrakeForce => brakeForce;

    }
}