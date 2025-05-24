using UnityEngine;

public class ModeloSelector : MonoBehaviour
{
    public GameObject modeloCasa;
    public GameObject modeloEdificio;
    public GameObject modeloEstructura;
    public GameObject modeloMonumento;
    public void MostrarCasa()
    {
        modeloCasa.SetActive(true);
        modeloEdificio.SetActive(false);
        modeloEstructura.SetActive(false);
        modeloMonumento.SetActive(false);
    }

    public void MostrarEdificio()
    {
        modeloCasa.SetActive(false);
        modeloEdificio.SetActive(true);
        modeloEstructura.SetActive(false);
        modeloMonumento.SetActive(false);
    }

    public void MostrarEstructura()
    {
        modeloCasa.SetActive(false);
        modeloEdificio.SetActive(false);
        modeloEstructura.SetActive(true);
        modeloMonumento.SetActive(false);
    }
    public void MostrarMonumento()
    {
        modeloCasa.SetActive(false);
        modeloEdificio.SetActive(false);
        modeloEstructura.SetActive(false);
        modeloMonumento.SetActive(true);
    }
}
