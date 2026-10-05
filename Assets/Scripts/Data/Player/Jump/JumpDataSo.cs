using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "JumpDataSo", menuName = "Scriptable Objects/JumpDataSo")]
    public class JumpDataSo : ScriptableObject
    {
        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;

        [SerializeField] private float _jumpCutMultiplier;
        public float JumpCutMultiplier => _jumpCutMultiplier;
    }
}

