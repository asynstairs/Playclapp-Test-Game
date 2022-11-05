using System.Collections;
using UnityEngine;
using Zenject;

public class ObjectsPoolingController : MonoBehaviour, IStoringSpawnedObjects
{
    public GameObject[] SpawnedGameObjects { get; private set; }

    [Inject] private SpawnController _spawnController;

    [SerializeField, Min(0f)] private float _delaySeconds;
    
    private void Awake()
    {
        
    }

    private void Start()
    {
        Initialize();
        StartCoroutine(Pool());
    }

    private void Initialize()
    {
        SpawnedGameObjects = _spawnController.SpawnedGameObjects;
    }

    private IEnumerator Pool()
    {
        foreach (var spawnedGameObject in SpawnedGameObjects)
        {
            spawnedGameObject.gameObject.SetActive(true);
            yield return new WaitForSeconds(_delaySeconds);
        }
    }
}