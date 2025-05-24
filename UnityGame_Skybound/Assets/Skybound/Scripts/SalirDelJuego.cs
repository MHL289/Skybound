using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SalirDelJuego : MonoBehaviour
{
    public void CerrarGame()
    {
        Debug.Log("Se ha cerrado la app");
        Application.Quit();
    }
}
