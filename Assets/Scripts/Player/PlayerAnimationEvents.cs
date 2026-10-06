using UnityEngine;
using System;

namespace Game.Player
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        public event Action OnThrowFinished;

        public void OnThrowFinishedAnimEvent()
        {
            OnThrowFinished?.Invoke();
        }
    }

}

