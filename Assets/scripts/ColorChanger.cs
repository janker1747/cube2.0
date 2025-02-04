using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.ChangeColorsCube += ChangeColor;
    }

    private void OnDisable()
    {
        _spawner.ChangeColorsCube -= ChangeColor;
    }

    public void ChangeColor(Cube cube)
    {
        MeshRenderer renderer = cube._renderer;

        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}
