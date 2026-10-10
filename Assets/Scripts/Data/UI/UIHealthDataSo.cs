using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "UIHealthDataSo", menuName = "Scriptable Objects/UIHealthDataSo")]
    public class UIHealthDataSo : ScriptableObject
    {
        [SerializeField] private float _displayTime;
        public float DisplayTime => _displayTime;
    }

}

