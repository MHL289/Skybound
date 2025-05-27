using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SonidoBotonAlPasarPuntero : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // fondo del botón (el Image)
    public AudioClip clip;
    public AudioSource audioSource;
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)  
            
        
            audioSource.PlayOneShot(clip);
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)

            return;
    }
}
