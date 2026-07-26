using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color color = Color.red;
    public float duration = .1f;

    private Color defaultcolor;

    private Tween _currTween;

    private void Start()
    {
        defaultcolor = meshRenderer.material.GetColor("_EmissionColor");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!_currTween.IsActive())
            meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
