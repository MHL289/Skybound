using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuPopUp : MonoBehaviour
{
    public GameObject popUp;

    public void ClickEnBotonPulsar()
    {
        Debug.Log("Se ha pulsado el boton");
    }


    public void MostrarPoUp()
    {
        popUp.SetActive(true);
    }
    public void CerrarPoUp()
    {
        popUp.SetActive(false);
    }
}
