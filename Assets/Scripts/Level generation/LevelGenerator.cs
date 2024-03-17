using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class LevelGenerator : MonoBehaviour
{
    [Header("Generation params")]
    [Range(0, 90)]
    [SerializeField] private float _angle;
    [Min(0)]
    [SerializeField] private float _min;
    [Min(0)]
    [SerializeField] private float _max;
    [Min(0)]
    [SerializeField] private float _height;

    [Header("Prefabs")]
    [SerializeField] private List<Element> _elements;
    [SerializeField] private AssetReference _checkpointPrefab;
    [SerializeField] private AssetReference _coinPrefab;

    [Header("Start elements")]
    [SerializeField] private GameObject _startElements;

    [Header("Spawned")]
    [SerializeField] private List<GameObject> _lastSpawned = new List<GameObject>();
    private Queue<GameObject> _checkpoints = new Queue<GameObject>();
    private INextPointGenerator _nextPointGenerator;

    private async void Awake()
    {
        var loadingTasks = new List<Task>();
        foreach(var elem in _elements)
        {
            loadingTasks.Add( elem.Wall.LoadAssetAsync<GameObject>().Task);
        }

        loadingTasks.Add(_coinPrefab.LoadAssetAsync<GameObject>().Task);
        loadingTasks.Add(_checkpointPrefab.LoadAssetAsync<GameObject>().Task);

        await Task.WhenAll(loadingTasks.ToArray());
        SetupLevel();
    }

    private void SetupLevel()
    {
        _nextPointGenerator = new AngleNextPointGenerator(_angle);
        GenerateLevelPart(Vector3.zero);
        AddStartElements(_startElements);
    }

    private void AddStartElements(GameObject startElements)
    {
        _lastSpawned.Add(startElements);
    }

    public void GenerateLevelPart(Vector3 start)
    {
        DeleteLastElements();
        SpawnCoin(start);

        var nextPosition = start;
        while (nextPosition.y < start.y + _height)
        {
            var distance = Random.Range(_min, _max);
            nextPosition = _nextPointGenerator.Get(nextPosition, distance);
            var element = _elements[Random.Range(0,_elements.Count)];

            _lastSpawned.Add(SpawnElement(element.Wall, nextPosition + element.Start));
            nextPosition += element.End;
        }
        nextPosition = _nextPointGenerator.Get(nextPosition, Random.Range(_min, _max));
        _checkpoints.Enqueue((GameObject) Instantiate(_checkpointPrefab.Asset, nextPosition, Quaternion.identity));
    }

    private void DeleteLastElements()
    {
        if (_checkpoints.Count > 1)
        {
            var lastCheckpoint = _checkpoints.Dequeue();
            if (!Addressables.ReleaseInstance(lastCheckpoint) && lastCheckpoint != null)
                Destroy(lastCheckpoint);
        }
        
        foreach (var anObject in _lastSpawned)
        {
            
                Destroy(anObject);
        }
        _lastSpawned.Clear();
    }

    private void SpawnCoin(Vector3 position)
    {
        var randX = Random.Range(-_max, _max);
        var randY = Random.Range(0, _height);
        var offset = new Vector3(randX, randY, 0f);
        _lastSpawned.Add((GameObject) Instantiate(_coinPrefab.Asset, position + offset, Quaternion.identity));
    }

    private GameObject SpawnElement(AssetReference reference, Vector3 position)
    {
        return (GameObject) Instantiate(reference.Asset, position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        foreach (var elem in _elements)
        {
            elem.Wall.ReleaseAsset();
        }

        _checkpointPrefab.ReleaseAsset();
        _coinPrefab.ReleaseAsset();
    }
}
