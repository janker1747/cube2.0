using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer _renderer;
    public event Action<Cube> Destroyed;

    public float CurrentChance { get; private set; } = 100f;
    public MeshRenderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void SetChance(float chance)
    {
        CurrentChance = chance;
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
