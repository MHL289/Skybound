using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffectySonido : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // fondo del botón (el Image)
    public AudioClip clip;
    public AudioSource audioSource;
    void Start()
    {
        // Asegúrate de ocultar el fondo al iniciar
        if (buttonImage != null)
            buttonImage.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)  
            buttonImage.enabled = true; // muestra el fondo
        
            audioSource.PlayOneShot(clip);
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.enabled = false; // oculta el fondo
        
    }
}
