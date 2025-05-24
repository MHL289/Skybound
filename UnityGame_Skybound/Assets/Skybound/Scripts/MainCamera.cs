using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public new Camera camera;

    void Start()
    {
        camera.enabled = false;  // Apagar camara al inicio
    }

    public void ActivarRA()
    {
        camera.enabled = true;   // Encender camara cuando se elija el modelo
    }
}
