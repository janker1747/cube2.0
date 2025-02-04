using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const int Divider = 2; 
    internal MeshRenderer _renderer;
    public event Action<Cube> Destroyed;
    public static event Action<Cube> AnyCubeDestroyed;
    public float CurrentChance { get; private set; } = 100f;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }


    public void SetChance(float chance)
    {
        CurrentChance = chance;
    }

    public void DestroyCube()
    {
        AnyCubeDestroyed?.Invoke(this);
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
 