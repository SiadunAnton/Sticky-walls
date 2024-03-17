using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private float _smooth = 0.5f;

    private void Update()
    {
        var characterRelative = new Vector3(_character.position.x,
                                            _character.position.y,
                                            transform.position.z);
        transform.position = Vector3.Lerp(transform.position, characterRelative, _smooth);
    }
}
