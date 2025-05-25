using UnityEngine;

public class ActivadorConInvoke : MonoBehaviour
{
    public GameObject objetoAActivar;           // El objeto que se activará
    public AudioSource sonidoAReproducir;       // El AudioSource con el sonido
    public float tiempoDeEspera = 5f;           // Tiempo en segundos antes de activar

    void Start()
    {
        Invoke("ActivarTodo", tiempoDeEspera);
    }

    void ActivarTodo()
    {
        if (objetoAActivar != null)
            objetoAActivar.SetActive(true);

        if (sonidoAReproducir != null)
            sonidoAReproducir.Play();
    }
}
