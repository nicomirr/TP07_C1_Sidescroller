using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "AnimationDataSo", menuName = "Scriptable Objects/AnimationDataSo")]
    public class AnimationDataSo : ScriptableObject
    {
        [SerializeField] private AnimationType _animationType;
        public AnimationType AnimationType => _animationType;

        [SerializeField] private string _animationName;
        public int AnimationHash => Animator.StringToHash(_animationName);
    }

}

