using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class AddressableSceneLoader : MonoBehaviour
{
    [SerializeField] private string _nextScene;

    public void LoadSceneAsync()
    {
        Addressables.LoadSceneAsync(_nextScene,LoadSceneMode.Single, true);
    }
}
