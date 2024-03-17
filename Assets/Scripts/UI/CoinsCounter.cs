using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    void Update()
    {
        _text.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
