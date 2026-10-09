using UnityEngine;
using System;
using Game.Data;

public class EnemyHealth
{
    public event Action<float, float> OnHealthChanged;

    private readonly float _maxHealth;
    private float _currentHealth;

    public EnemyHealth(EnemyDataSo data)
    {
        _maxHealth = data.MaxHealth;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
