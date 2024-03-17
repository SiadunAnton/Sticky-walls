using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Create environment theme", fileName = "EnvironmentTheme")]
public class EnvironmentTheme : ScriptableObject
{
    [SerializeField] private List<WallSpriteEntry> _wallSprites;

    private Dictionary<string, Sprite> _pairDictionary = new Dictionary<string, Sprite>();

    private void OnEnable()
    {
        foreach (var entry in _wallSprites)
        {
            _pairDictionary.Add(entry.Name, entry.Sprite);
        }
        Debug.Log("Refresh dict.");
    }

    [Serializable]
    public class WallSpriteEntry
    {
        public string Name;
        public Sprite Sprite;
    }

    public Sprite GetSprite(string name)
    {
        if (!_pairDictionary.ContainsKey(name))
            throw new NullReferenceException($"Cant find sprite with {name} in theme"); 
        return _pairDictionary[name];
    }
}
