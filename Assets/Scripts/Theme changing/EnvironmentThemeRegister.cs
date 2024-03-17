using System;
using UnityEngine.AddressableAssets;
using UnityEngine;

public class EnvironmentThemeRegister : MonoBehaviour
{
    public EnvironmentTheme Theme
    {
        get
        {
            if ( _currentTheme == null)
                throw new ArgumentNullException("Theme wasn't loaded.");
            return _currentTheme;
        }
    }

    [SerializeField] private AssetReference _defaultReference;

    private EnvironmentTheme _currentTheme;

    private void Start()
    {
        SetTheme(_defaultReference);
    }

    public void SetTheme(AssetReference themeReference)
    {
        var asyncOpHandle = Addressables.LoadAssetAsync<EnvironmentTheme>(themeReference);
        asyncOpHandle.Completed += x =>
        {
            _currentTheme = asyncOpHandle.Result;
            Debug.Log($"Theme {themeReference.SubObjectName} was loaded");
        };
    }
}
