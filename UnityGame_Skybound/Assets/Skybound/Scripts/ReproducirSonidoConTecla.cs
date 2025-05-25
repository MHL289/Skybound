using UnityEngine;

public class SonidoMientrasSePresiona : MonoBehaviour
{
    public AudioSource sonidoAReproducir;  // Arrastra aqu� tu AudioSource
    public KeyCode tecla = KeyCode.W; // Cambia la tecla si deseas

    void Update()
    {
        if (Input.GetKey(tecla))
        {
            if (!sonidoAReproducir.isPlaying)
                sonidoAReproducir.Play();
        }

        if (Input.GetKeyUp(tecla))
        {
            if (sonidoAReproducir.isPlaying)
                sonidoAReproducir.Stop();
        }
    }
}
