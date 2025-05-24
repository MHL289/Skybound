
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image PanelBrillo;
    public Image PanelBrillo1;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, sliderValue);

        slider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
        PanelBrillo1.color = new Color(PanelBrillo1.color.r, PanelBrillo1.color.g, PanelBrillo1.color.b, sliderValue);

    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Brillo", sliderValue);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, sliderValue);

        sliderValue = valor;
        PlayerPrefs.SetFloat("Brillo", sliderValue);
        PanelBrillo1.color = new Color(PanelBrillo1.color.r, PanelBrillo1.color.g, PanelBrillo1.color.b, sliderValue);

    }

    
}
