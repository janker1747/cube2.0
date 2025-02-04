using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    private Camera _camera;

    private int _mouseButton = 0;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            RayLine();
        }
    }

    private void RayLine()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                cube.DestroyCube();
            }
        }
    }
}
