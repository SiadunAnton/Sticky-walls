using UnityEngine;
using System;
using Zenject;

public class WallSpriteAdjust : MonoBehaviour
{
    [SerializeField] private string _name;

    private SpriteRenderer _renderer;
    private EnvironmentThemeRegister _themeRegister;

    [Inject]
    public void Initialize(EnvironmentThemeRegister themeRegister)
    {
        _themeRegister = themeRegister ?? throw new NullReferenceException("ThemeRegister is empty.");
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InstallSprite();
    }

    private void InstallSprite()
    {
        if (_themeRegister == null)
            throw new NullReferenceException("Theme register doesnt binded");

        var sprite = _themeRegister.Theme.GetSprite(_name);
        if (_themeRegister.Theme == null)
            throw new NullReferenceException("Theme  doesnt binded");
        if (sprite == null)
            throw new NullReferenceException("Sprite  doesnt binded");
        _renderer.sprite = sprite;
    }

}
