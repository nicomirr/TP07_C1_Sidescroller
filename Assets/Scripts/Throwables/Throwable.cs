using UnityEngine;
using Game.Data;

namespace Game.Throwables
{
    public class Throwable : MonoBehaviour
    {
        [SerializeField] private ThrowableDataSo _data;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Throw(Vector2 startingPos, float direction)
        {
            this.transform.position = startingPos;

            _rb.linearVelocity = new Vector2(Mathf.Sign(direction) * _data.HorizontalSpeed, _data.VerticalSpeed);
        }
    }
}
