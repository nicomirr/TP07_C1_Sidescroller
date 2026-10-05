using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "GravityDataSo", menuName = "Scriptable Objects/GravityDataSo")]
    public class GravityDataSo : ScriptableObject
    {
        [SerializeField] private float _risingGravity;
        public float RisingGravity => _risingGravity;

        [SerializeField] private float _fallingGravity;
        public float FallingGravity => _fallingGravity;

        [SerializeField] private float _apexGravity;
        public float ApexGravity => _apexGravity;

        [SerializeField] private float _apexVelocityThreshold;
        public float ApexVelocityThreshold => _apexVelocityThreshold;
    }

}
