using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TweenPractice : MonoBehaviour
{
    [SerializeField] private Transform _movingSphere;
    [SerializeField] private Transform _spinningCube;
    [SerializeField] private Transform _scalingCapsule;
    [SerializeField] private Transform _movingSpinningScalingCube;
    [SerializeField] private Transform _colorChangingSphere;
    [SerializeField] private Text _shiftingText;

    private Material _colorChangingSphereMaterial;

    private void Awake()
    {
        _colorChangingSphereMaterial = _colorChangingSphere.GetComponent<MeshRenderer>().material;

        StartTweens();
    }

    private void StartTweens()
    {
        _movingSphere
            .DOMoveZ(2f, 1f)
            .SetEase(Ease.InOutExpo)
            .SetLoops(-1, LoopType.Yoyo);

        _spinningCube
            .DOLocalRotate(new Vector3(0f, 360f, 0f), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

        _scalingCapsule
            .DOScale(1.5f, 1f)
            .SetEase(Ease.InOutExpo)
            .SetLoops(-1, LoopType.Yoyo);

        Sequence moveSpinScale = DOTween.Sequence(_movingSpinningScalingCube);
        moveSpinScale.Insert(0f, _movingSpinningScalingCube.DOMoveZ(4f, 1f));
        moveSpinScale.Insert(0f, _movingSpinningScalingCube.DOLocalRotate(new Vector3(0f, 360f, 0f), 1f, RotateMode.FastBeyond360));
        moveSpinScale.Insert(0f, _movingSpinningScalingCube.DOScale(0.25f, 1f));
        moveSpinScale.SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

        _colorChangingSphereMaterial
            .DOColor(Color.blue, 1f)
            .SetEase(Ease.InOutExpo)
            .SetLoops(-1, LoopType.Yoyo);

        Sequence textChange = DOTween.Sequence(_shiftingText);
        textChange.AppendInterval(1f);
        textChange.Append(_shiftingText.DOText("Replaced!", 2f));
        textChange.Append(_shiftingText.DOText(" And added!", 2f).SetRelative());
        textChange.Append(_shiftingText.DOText("But now hacked!", 2f, scrambleMode: ScrambleMode.All));
        textChange.SetLoops(-1, LoopType.Restart);
    }
}
