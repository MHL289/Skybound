using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovimientoDelAvion : MonoBehaviour
{
    [Header("Velocidad y vuelo")]
    public float velocidadActual = 20f;
    public float velocidadMinima = 20f;
    public float aceleracion = 30f;
    public float desaceleracion = 20f;

    [Header("Sensibilidad de vuelo")]
    public float sensibilidadBase = 2f;
    public float suavizado = 7f;
    public float maxRollAngle = 60f;
    public float rollSuavizado = 0.9f;

    [Header("Rotación por teclas")]
    public float rotacionTeclaGradosPorSegundo = 15f;

    [Header("Marchas")]
    private int marchaActual = 1;
    private int marchasMaximas = 4;
    public float[] velocidadPorMarcha = { 30f, 60f, 90f, 120f };

    [Header("UI de marchas")]
    public Button[] botonesMarcha; // 0 = marcha 1, 1 = marcha 2, etc.
    public Color colorActivo = Color.green;
    public Color colorInactivo = Color.white;
    public float escalaActiva = 1.2f;
    public float escalaNormal = 1f;
    public float duracionAnimacion = 0.2f;
    public AudioSource sonidoCambioMarcha;

    [Header("Slider de velocidad")]
    public Slider velocidadSlider;

    [Header("Distancia recorrida")]
    public float distanciaRecorrida = 0f;
    public TMP_Text distanciaTexto; // Arrástralo en el inspector

    // Internos
    private Vector2 rotacionMouse;
    private Vector2 rotacionActual;
    private float rollActual = 0f;
    private Vector3[] escalasOriginales;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Guardar escalas originales
        escalasOriginales = new Vector3[botonesMarcha.Length];
        for (int i = 0; i < botonesMarcha.Length; i++)
        {
            escalasOriginales[i] = botonesMarcha[i].transform.localScale;
        }

        ActualizarBotonesMarcha();
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float velocidadMaximaActual = velocidadPorMarcha[marchaActual - 1];

        // Aceleración y desaceleración con W
        if (Input.GetKey(KeyCode.W))
        {
            velocidadActual += aceleracion * Time.deltaTime;
        }
        else
        {
            velocidadActual -= desaceleracion * Time.deltaTime;
        }

        velocidadActual = Mathf.Clamp(velocidadActual, velocidadMinima, velocidadMaximaActual);
        transform.position += transform.forward * velocidadActual * Time.deltaTime;

        // Actualizar distancia recorrida
        distanciaRecorrida += velocidadActual * Time.deltaTime;

        // Mostrar distancia
        if (distanciaTexto != null)
        {
            distanciaTexto.text = "Distancia: " + Mathf.FloorToInt(distanciaRecorrida) + " m";
        }

        // Actualizar Slider
        if (velocidadSlider != null)
        {
            velocidadSlider.maxValue = velocidadMaximaActual;
            velocidadSlider.value = velocidadActual;
        }

        // Cambio de marchas
        if (Input.GetKeyDown(KeyCode.Q) && marchaActual < marchasMaximas)
        {
            marchaActual++;
            ActualizarBotonesMarcha();
        }
        if (Input.GetKeyDown(KeyCode.E) && marchaActual > 1)
        {
            marchaActual--;
            ActualizarBotonesMarcha();
        }

        // Movimiento con mouse
        float sensibilidadVelocidad = Mathf.Lerp(sensibilidadBase, sensibilidadBase * 0.2f, velocidadActual / 120f);
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadVelocidad;
        rotacionMouse.y -= mouseY;
        rotacionMouse.y = Mathf.Clamp(rotacionMouse.y, -80f, 80f);

        // Movimiento con teclas A y D
        if (Input.GetKey(KeyCode.D))
        {
            rotacionMouse.x += rotacionTeclaGradosPorSegundo * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotacionMouse.x -= rotacionTeclaGradosPorSegundo * Time.deltaTime;
        }

        // Suavizado
        rotacionActual = Vector2.Lerp(rotacionActual, rotacionMouse, Time.deltaTime * suavizado);

        // Roll automático
        float objetivoRoll = Mathf.Clamp(-((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)) * maxRollAngle, -maxRollAngle, maxRollAngle);
        rollActual = Mathf.Lerp(rollActual, objetivoRoll, Time.deltaTime * rollSuavizado);

        // Aplicar rotación al avión
        transform.rotation = Quaternion.Euler(rotacionActual.y, rotacionActual.x, rollActual);
    }

    void ActualizarBotonesMarcha()
    {
        for (int i = 0; i < botonesMarcha.Length; i++)
        {
            Button btn = botonesMarcha[i];
            bool esActiva = (i == marchaActual - 1);

            ColorBlock cb = btn.colors;
            cb.normalColor = esActiva ? colorActivo : colorInactivo;
            cb.highlightedColor = cb.normalColor;
            btn.colors = cb;

            StopCoroutine("AnimarEscala");
            StartCoroutine(AnimarEscala(btn.transform, esActiva ? escalaActiva : escalaNormal, i));

            if (esActiva && sonidoCambioMarcha != null)
            {
                sonidoCambioMarcha.Play();
            }
        }
    }

    IEnumerator AnimarEscala(Transform target, float escalaFactor, int index)
    {
        Vector3 escalaInicial = target.localScale;
        Vector3 escalaBase = escalasOriginales[index];
        Vector3 escalaFinal = escalaBase * escalaFactor;

        float tiempo = 0f;
        while (tiempo < duracionAnimacion)
        {
            tiempo += Time.unscaledDeltaTime;
            target.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tiempo / duracionAnimacion);
            yield return null;
        }

        target.localScale = escalaFinal;
    }
}
