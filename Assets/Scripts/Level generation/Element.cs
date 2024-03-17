using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Level element",fileName = "Element")]
public class Element : ScriptableObject
{
    public AssetReference Wall;
    public Vector3 Start;
    public Vector3 End;
}
