using UnityEngine;

public class SceneHistoryManager : MonoBehaviour
{
    public static SceneHistoryManager Instance;
    public string escenaAnterior;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Vive entre escenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public void GuardarEscena(string nombreEscena)
    {
        escenaAnterior = nombreEscena;
    }

    public string ObtenerEscenaAnterior()
    {
        return escenaAnterior;
    }
}
