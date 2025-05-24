using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string escenaDestino;

    public void CambiarEscena()
    {
        if (SceneHistoryManager.Instance != null)
        {
            string escenaActual = SceneManager.GetActiveScene().name;
            SceneHistoryManager.Instance.GuardarEscena(escenaActual);
        }

        SceneManager.LoadScene(escenaDestino);
    }
}
