using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour, IStoringSpawnedObjects
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private uint Count;
    public GameObject[] SpawnedGameObjects { get; private set; }
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        SpawnedGameObjects = new GameObject[Count];
    }

    [MenuItem("Prespawn with given count")]
    private void Spawn(float count)
    {
        int countPrefabsCached = _prefabs.Length;
        
        for (int i = 0; i < Count; ++i)
        {
            int j = Random.Range(0, countPrefabsCached);
            SpawnedGameObjects[i] = Instantiate(_prefabs[j], _spawnPoint.position, Quaternion.identity);
        }
    }
}