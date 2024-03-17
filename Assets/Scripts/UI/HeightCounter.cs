using UnityEngine;
using TMPro;

public class HeightCounter : MonoBehaviour
{
    [SerializeField] private Transform _trackedObject;
    [SerializeField] private TMP_Text _text;

    private int _height = 0;

    private void FixedUpdate()
    {
        int currentHeight = (int)_trackedObject.position.y;
        _height = _height > currentHeight ? _height : currentHeight;
        _text.text = _height.ToString();
    }

}
