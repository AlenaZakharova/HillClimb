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
        [SerializeField] private float deltaForwardSpeed;
        [SerializeField] private float deltaRearSpeed;

        [Header("GameScreen")] 
        [SerializeField] private Sprite brakePedal;
        [SerializeField] private Sprite brakePedalPressed;
        [SerializeField] private Sprite gasPedal;
        [SerializeField] private Sprite gasPedalPressed;

        public float SmoothTime => smoothTime;
        
        public Car CarPrefab => carPrefab;
        public Vector3 StartPosition => startPosition;
        public float DeltaForwardSpeed => deltaForwardSpeed;
        public float DeltaRearSpeed => deltaRearSpeed;

        public Sprite BrakePedal => brakePedal;
        public Sprite BrakePedalPressed => brakePedalPressed;
        public Sprite GasPedal => gasPedal;
        public Sprite GasPedalPressed => gasPedalPressed;

    }
}