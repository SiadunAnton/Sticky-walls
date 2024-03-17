using UnityEngine;
using Zenject;
using System;

public class SpriteController : MonoBehaviour
{
    private Respawner _respawner;
    private Transform _characterTransform;

    [Inject]
    public void Initialize(Respawner respawner,[Inject(Id = "CharacterTransform")]Transform character)
    {
        _respawner = respawner ?? throw new NullReferenceException("Respawner is empty.");
        _characterTransform = character ?? throw new NullReferenceException("Character tranform is empty.");
    }

    private void Start()
    {
        _respawner.OnRespawned += x => _characterTransform.localScale =
                                            new Vector3(-Mathf.Abs(_characterTransform.localScale.x),
                                                        _characterTransform.localScale.y,
                                                        _characterTransform.localScale.z);
    }
   
    public void ReverseScale()
    {
        SetScale(-1);
    }

    private void SetScale(int multipier)
    {
        transform.localScale = new Vector3(multipier * transform.localScale.x,
                         transform.localScale.y,
                         transform.localScale.z);
    }

    public void ScaleToObject(Vector3 objectPosition)
    {
        if (transform.position.x < objectPosition.x)
            SetPositiveScale();
        else
            SetNegativeScale();
    }

    private void SetPositiveScale()
    {
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x),
                         transform.localScale.y,
                         transform.localScale.z);
    }

    private void SetNegativeScale()
    {
        transform.localScale = new Vector3(-Math.Abs(transform.localScale.x),
                         transform.localScale.y,
                         transform.localScale.z);
    }
}
