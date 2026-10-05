using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.AnimationSystem
{
    public class AnimationLibrary
    {
        private readonly Object _context;

        private readonly Dictionary<AnimationType, int> _animations = new();

        public AnimationLibrary(AnimationConfigSo data, Object context)
        {
            foreach(AnimationDataSo animationData in data.Animations)
            {
                _animations.Add(animationData.AnimationType, animationData.AnimationHash);
            }

            _context = context;
        }

        public bool TryGetHash(AnimationType animationType, out int hash)
        {
            if(!_animations.TryGetValue(animationType, out hash))
            {
                Debug.LogError("Error. No existe la animación " +  animationType.ToString() + " en el diccionario.", _context);
                return false;
            }

            return true;
        }
    }

}
