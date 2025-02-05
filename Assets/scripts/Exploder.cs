using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _radius = 500f;
    private float _force = 100f;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.NotSpawnCube += OnCubeDestroyed;
    }

    private void OnDisable()
    {
        _spawner.NotSpawnCube -= OnCubeDestroyed;
    }

    private void OnCubeDestroyed(Cube cube)
    {
        Explode(cube.transform.position, cube);
    }

    public void Explode(Vector3 explosionPosition, Cube cube)
    {
        float scale = cube.transform.localScale.x;
        float explosionRadius = _radius * scale;
        float explosionForce = _force * scale;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                Vector3 explosionDirection = (collider.transform.position - explosionPosition).normalized;
                rigidbody.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }
        }
    }
}
