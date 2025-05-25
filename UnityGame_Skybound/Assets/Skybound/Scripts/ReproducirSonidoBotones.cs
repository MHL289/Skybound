using UnityEngine;
using UnityEngine.UI;

public class BotonSonido : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void ReproducirSonido()
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
