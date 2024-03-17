using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PhoenixHeat : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _color;
    [SerializeField] private Light2D _light;

    private bool _isActive = false;
    private float _cachedOuterRadius;
    private Color _cachedColor;

    private void Awake()
    {
        Save();
    }

    public void Activate()
    {
        if (!_isActive)
        {
            StartCoroutine(HeatProcess());
        }
    }

    IEnumerator HeatProcess()
    {
        _isActive = true;
        Save();
        Set();
        yield return new WaitForSeconds(_duration);
        Reset();
    }

    private void Set()
    {
        _light.pointLightOuterRadius = _cachedOuterRadius * 2;
        _light.color = _color;
    }

    private void Save()
    {
        _cachedOuterRadius = _light.pointLightOuterRadius;
        _cachedColor = _light.color;
    }

    private void Reset()
    {
        _light.pointLightOuterRadius = _cachedOuterRadius;
        _light.color = _cachedColor;
        _isActive = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Reset();
    }
}
