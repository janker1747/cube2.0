using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    internal MeshRenderer _renderer;
    private const int Divider = 2; 

    public float CurrentChance { get; private set; } = 100f;

    public event Action<Cube> Destroyed;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void SetChance(float chance)
    {
        CurrentChance = chance;
    }

    public void HalveChance()
    {
        CurrentChance /= Divider;
    }

    public void DestroyCube()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
