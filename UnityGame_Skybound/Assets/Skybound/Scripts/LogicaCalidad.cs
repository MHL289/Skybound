
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LogicaCalidad : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;

    // Start is called before the first frame update void Start()
    void Start()
    {
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3); 
        dropdown.value = calidad; AjustarCalidad();
    }
    
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value); 
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value); 
        calidad = dropdown.value;
    }
}