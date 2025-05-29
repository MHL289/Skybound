using UnityEngine;
using UnityEngine.UI;
using TMPro; // Solo si usas TextMeshPro

public class CronometroMision : MonoBehaviour
{

    public GameObject menuPausaUIPerderMision;
    public bool juegoPausadoEnPerderMision = false;
    

    [Header("Tiempo de misión")]
    public float tiempoInicial = 90f; // segundos
    private float tiempoRestante;
    private bool tiempoActivo = true;

    [Header("UI del cronómetro")]
    public TMP_Text textoTiempo; // usa Text si no usas TMP

    void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarTextoTiempo();
    }

    void Update()
    {
        if (!tiempoActivo) return;

        tiempoRestante -= Time.deltaTime;
        tiempoRestante = Mathf.Max(tiempoRestante, 0f); // evitar negativos

        ActualizarTextoTiempo();

        if (tiempoRestante <= 0)
        {
            tiempoActivo = false;
            PerderMision();

        }


    }

    void ActualizarTextoTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public void CompletarMision()
    {
        if (!tiempoActivo) return;

        tiempoActivo = false;
        Debug.Log("¡MISIÓN COMPLETADA!");
        // Aquí puedes mostrar UI de victoria, cambiar de escena, etc.
    }

    void PerderMision()
    {
        Debug.Log("Tiempo agotado. ¡MISIÓN FALLIDA!");

        menuPausaUIPerderMision.SetActive(true);
        Time.timeScale = 0f;
        juegoPausadoEnPerderMision = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Aquí puedes mostrar UI de derrota, reiniciar nivel, etc.
        

    }


}
