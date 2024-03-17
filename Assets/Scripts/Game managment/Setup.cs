using UnityEngine;

public class Setup : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }
}
