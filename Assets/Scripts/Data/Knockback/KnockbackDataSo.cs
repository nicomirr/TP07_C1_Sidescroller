using UnityEngine;

[CreateAssetMenu(fileName = "KnockbackDataSo", menuName = "Scriptable Objects/KnockbackDataSo")]
public class KnockbackDataSo : ScriptableObject
{
    [SerializeField] private float _horizontalKnockbackForce;
    public float HorizontalKnockbackForce => _horizontalKnockbackForce;

    [SerializeField] private float _verticalKnockbackForce;
    public float VerticalKnockbackForce => _verticalKnockbackForce;
}
