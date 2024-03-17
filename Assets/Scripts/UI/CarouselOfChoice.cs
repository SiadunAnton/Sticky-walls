using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarouselOfChoice : MonoBehaviour
{
    [SerializeField] private List<GameObject> _choices;

    private int _selectedIndex = 0;

    private void Start()
    {
        foreach (var choice in _choices)
            PrepareUIElement(choice);
        ShowUIElement(0);
    }

    private void PrepareUIElement(GameObject element)
    {
        element.SetActive(false);
        element.transform.position = transform.position;
    }

    public void Previous()
    {
        HideUIElement(_selectedIndex);
        _selectedIndex -= 1;
        if (_selectedIndex < 0)
            _selectedIndex = _choices.Count - 1;
        ShowUIElement(_selectedIndex);
    }

    public void Next()
    {
        HideUIElement(_selectedIndex);
        _selectedIndex += 1;
        if (_selectedIndex >= _choices.Count)
            _selectedIndex = 0;
        ShowUIElement(_selectedIndex);
    }

    private void ShowUIElement(int index)
    {
        Transform choiceTransform = _choices[index].transform;
        choiceTransform.localScale = Vector3.zero;
        _choices[index].SetActive(true);
        choiceTransform.DOScale( Vector3.one, 1f);
    }

    private void HideUIElement(int index)
    {
        _choices[index].SetActive(false);
    }
}
