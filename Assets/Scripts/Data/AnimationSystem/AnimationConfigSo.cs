using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "AnimationConfigSo", menuName = "Scriptable Objects/AnimationConfigSo")]
    public class AnimationConfigSo : ScriptableObject
    {
        [SerializeField] private List<AnimationDataSo> _animations;
        public List<AnimationDataSo> Animations => _animations;
    }

}

