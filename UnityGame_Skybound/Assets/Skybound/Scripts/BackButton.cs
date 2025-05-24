using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        string escenaAnterior = SceneHistoryManager.Instance.ObtenerEscenaAnterior();

        if (!string.IsNullOrEmpty(escenaAnterior))
        {
            Debug.Log("Volviendo a la escena: " + escenaAnterior);
            SceneManager.LoadScene(escenaAnterior);
        }
        else
        {
            Debug.LogWarning("No hay escena anterior guardada.");
        }
    }
}
