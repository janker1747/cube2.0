using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _radius = 500f;
    private float _force = 100f;

    private void OnEnable()
    {
        Cube.AnyCubeDestroyed += OnCubeDestroyed;
    }

    private void OnDisable()
    {
        Cube.AnyCubeDestroyed -= OnCubeDestroyed;
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
                rigidbody.AddForce(explosionDirection * _force, ForceMode.Impulse);
            }
        }
    }
}
