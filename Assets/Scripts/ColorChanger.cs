using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;
    [SerializeField] private LoopType _loopType;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;

        StartTween();
    }

    private void StartTween()
    {
        _material
            .DOColor(_color, _duration)
            .SetEase(_ease)
            .SetLoops(-1, _loopType);
    }
}
