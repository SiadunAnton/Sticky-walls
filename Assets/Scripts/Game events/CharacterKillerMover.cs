using System;
using UnityEngine;
using Zenject;

public class CharacterKillerMover : MonoBehaviour
{
    [SerializeField] private GameObject _killer;
    [SerializeField] private float _verticalOffset;

    private Respawner _respawner;

    [Inject]
    public void Initialize(Respawner respawner)
    {
        _respawner = respawner ?? throw new NullReferenceException("Respawner is empty.");
    }

    private void Start()
    {
        _respawner.OnRespawned += x => MoveTo(x + new Vector3(0f, _verticalOffset, 0f));
    }

    public void MoveTo(Vector3 position)
    {
        _killer.SetActive(false);
        _killer.transform.position = position;
        _killer.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform") || collision.CompareTag("Wall"))
        {
            MoveTo(collision.transform.position + new Vector3(0f, _verticalOffset, 0f));
        }
    }
}
