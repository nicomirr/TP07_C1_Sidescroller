using UnityEngine;
using Game.Data;
using Game.Core;
using Game.ParticleEffects;

namespace Game.Throwables
{
    public class Throwable : MonoBehaviour
    {
        [SerializeField] private ThrowableDataSo _data;

        private Rigidbody2D _rb;

        private float _throwableTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _throwableTimer = 0;
        }

        private void Update()
        {
            _throwableTimer += Time.deltaTime;

            if (_throwableTimer >= _data.LifeTime)
                this.gameObject.SetActive(false);

        }

        public void Throw(Vector2 startingPos, float direction, Vector2 throwerVelocity)
        {
            this.transform.position = startingPos;

            _rb.linearVelocity = new Vector2(throwerVelocity.x + (Mathf.Sign(direction) * _data.HorizontalSpeed), _data.VerticalSpeed);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.RockImpact, this.transform.position));
            this.gameObject.SetActive(false);
        }
    }
}
