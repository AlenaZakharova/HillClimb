using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private GameObject playerNamePrefab;

        [Header("Camera")] 
        [SerializeField] float cameraStickiness;
        [SerializeField] float cameraRotationStickiness;
        [SerializeField] float cameraAdditionalVerticalRotation;


        public float CameraStickiness => cameraStickiness;
        public float CameraRotationStickiness => cameraRotationStickiness;
        public float CameraAdditionalVerticalRotation => cameraAdditionalVerticalRotation;

    }
}