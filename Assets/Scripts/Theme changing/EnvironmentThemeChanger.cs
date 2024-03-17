using UnityEngine;
using Zenject;
using System;
using UnityEngine.AddressableAssets;

public class EnvironmentThemeChanger : MonoBehaviour
{
    [SerializeField] private AssetReference _themeReference;

    private EnvironmentThemeRegister _themeRegister;

    [Inject]
    public void Initialize(EnvironmentThemeRegister themeRegister)
    {
        _themeRegister = themeRegister ?? throw new NullReferenceException("Theme register is empty.");
    }

    public void SetTheme()
    {
        _themeRegister.SetTheme(_themeReference);
    }
}
