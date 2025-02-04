using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _radius = 500f;
    private float _force = 100f;

    public void Explode(Vector3 explosionPosition, Cube cube)
    {
        float scale = cube.transform.localScale.x;
        float explosionRadius = _radius * scale;
        float explosionForce = _force * scale;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigibody = collider.GetComponent<Rigidbody>();

            if (rigibody != null)
            {
                rigibody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            }
        }
    }
}
