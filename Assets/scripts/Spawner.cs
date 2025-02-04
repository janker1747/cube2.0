using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Cube _cube;
    private Exploder _explosion;
    public event Action<Cube> ChangeColorsCube;

    private void Awake()
    {
        _explosion = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        Cube.AnyCubeDestroyed += HandleCubeDestruction;
    }

    private void OnDisable()
    {
        Cube.AnyCubeDestroyed -= HandleCubeDestruction;
    }

    private void HandleCubeDestruction(Cube destroyedCube)
    {
        if (destroyedCube == null)
        {
            return;
        }

        destroyedCube.Destroyed -= HandleCubeDestruction; 
        Vector3 position = destroyedCube.transform.position;
        Vector3 scale = destroyedCube.transform.localScale;

        TrySpawnNewCubes(position, scale, destroyedCube);
    }

    private void TrySpawnNewCubes(Vector3 position, Vector3 scale, Cube cube)
    {
        float minValue = 0f;
        float maxValue = 101f;

        float randomValue = UnityEngine.Random.Range(minValue, maxValue);

        if (randomValue < cube.CurrentChance)
        {
            SpawnCubes(position, scale, cube);
        }
    }

    private void SpawnCubes(Vector3 position, Vector3 scale, Cube destroyedCube)
    {
        float minValue = 2f;
        float maxValue = 6f;

        float randomCount = UnityEngine.Random.Range(minValue, maxValue);

        for (int i = 0; i < randomCount; i++)
        {
           InstantiateCube(position, scale, destroyedCube);
        }
    }

    private void InstantiateCube(Vector3 position, Vector3 scale, Cube destroyedCube)
    {
        int divider = 2;
        Cube cube = Instantiate(_prefab, position + Vector3.up, Quaternion.identity);
        cube.transform.localScale = scale / divider;

        cube.SetChance(destroyedCube.CurrentChance /2 );
        cube.Destroyed += HandleCubeDestruction; 

        ChangeColorsCube?.Invoke(cube); 
    }
}
